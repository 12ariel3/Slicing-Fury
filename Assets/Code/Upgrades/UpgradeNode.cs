using Assets.Code.Common.Events;
using Assets.Code.Common.NodesData;
using Assets.Code.Common.UpgradesData;
using Assets.Code.Core;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Code.Upgrades
{
    public class UpgradeNode : MonoBehaviour, EventObserver
    {
        [SerializeField] private Button _nodeButton;
        [SerializeField] private Image _nodeWay;
        [SerializeField] private Image _nodeIcon;
        [SerializeField] private Image _nodeIconBackground;
        [SerializeField] private Image _nodeIconDeepBackground;

        [SerializeField] private UpgradeNodeToSpawnConfiguration _nodeToSpawnConfiguration;

        private Color _nodeWayColor;

        private void Awake()
        {
            _nodeWayColor.a = 1;
            _nodeWayColor.r = 0;
            _nodeWayColor.g = 1;
            _nodeWayColor.b = 0;
        }
        private void Start()
        {
            ServiceLocator.Instance.GetService<EventQueue>().Subscribe(EventIds.UpgradeNodeActived, this);
            ServiceLocator.Instance.GetService<EventQueue>().Subscribe(EventIds.UpgradeCheckForAvailability, this);
            CheckForAvailabilityAndActivation();
        }

        private void OnDestroy()
        {
            ServiceLocator.Instance.GetService<EventQueue>().Unsubscribe(EventIds.UpgradeNodeActived, this);
            ServiceLocator.Instance.GetService<EventQueue>().Unsubscribe(EventIds.UpgradeCheckForAvailability, this);
        }

        public void CheckForAvailabilityAndActivation()
        {

            if (ServiceLocator.Instance.GetService<NodesSystem>().GetNodeAvailability(_nodeToSpawnConfiguration.NodeAvailableId))
            {
                _nodeButton.onClick.AddListener(OnNodePressed);
            }
            if (ServiceLocator.Instance.GetService<NodesSystem>().GetNodeActivation(_nodeToSpawnConfiguration.NodeId))
            {
                _nodeButton.interactable = false;
                _nodeWay.color = _nodeWayColor;
            }
        }
        private void OnNodePressed()
        {
            var upgradesPanelEventData = new UpgradesPanelEventData(_nodeToSpawnConfiguration.NodeId, _nodeToSpawnConfiguration.NextNodeAvailableId1,
                                                                    _nodeToSpawnConfiguration.NextNodeAvailableId2,
                                                                    _nodeToSpawnConfiguration.StatsToAdd, _nodeToSpawnConfiguration.GemCost,
                                                                    _nodeIcon, _nodeIconBackground, _nodeIconDeepBackground, GetInstanceID());

            ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(upgradesPanelEventData);
        }


        private void ActiveThisNode()
        {
            var nodeSystem = ServiceLocator.Instance.GetService<NodesSystem>();
            nodeSystem.SaveNodeActivation(_nodeToSpawnConfiguration.NodeId, true);
            nodeSystem.SaveNodeAvailability(_nodeToSpawnConfiguration.NodeAvailableId, false);

            if (_nodeToSpawnConfiguration.NextNodeAvailableId1 != "None")
            {
                nodeSystem.SaveNodeAvailability(_nodeToSpawnConfiguration.NextNodeAvailableId1, true);
            }
            if (_nodeToSpawnConfiguration.NextNodeAvailableId2 != "None")
            {
                nodeSystem.SaveNodeAvailability(_nodeToSpawnConfiguration.NextNodeAvailableId2, true);
            }

            _nodeButton.interactable = false;
            _nodeWay.color = _nodeWayColor;

            CheckClassAndSaveStats();
        }

        private void CheckClassAndSaveStats()
        {
            switch (_nodeToSpawnConfiguration.NodeClass)
            {
                case "Attack":
                    var previousAttack = ServiceLocator.Instance.GetService<UpgradesSystem>().GetUpgradeAttack();
                    var newUpgradeAttackValue = previousAttack + _nodeToSpawnConfiguration.StatsToAdd;
                    ServiceLocator.Instance.GetService<UpgradesSystem>().SaveUpgradeAttack(newUpgradeAttackValue);
                    return;

                case "Hp":
                    var previousHp = ServiceLocator.Instance.GetService<UpgradesSystem>().GetUpgradeHp();
                    var newUpgradeHpValue = previousHp + _nodeToSpawnConfiguration.StatsToAdd;
                    ServiceLocator.Instance.GetService<UpgradesSystem>().SaveUpgradeHp(newUpgradeHpValue);
                    return;

                case "CriticalProbability":
                    var previousCriticalProbability = ServiceLocator.Instance.GetService<UpgradesSystem>().GetUpgradeCriticalProbability();
                    var newUpgradeCriticalProbabilityValue = previousCriticalProbability + _nodeToSpawnConfiguration.StatsToAdd;
                    ServiceLocator.Instance.GetService<UpgradesSystem>().SaveUpgradeCriticalProbability(newUpgradeCriticalProbabilityValue);
                    return;

                case "CriticalMultiplier":
                    var previousCriticalMultiplier = ServiceLocator.Instance.GetService<UpgradesSystem>().GetUpgradeCriticalMultiplier();
                    var newUpgradeCriticalMultiplierValue = previousCriticalMultiplier + _nodeToSpawnConfiguration.StatsToAdd;
                    ServiceLocator.Instance.GetService<UpgradesSystem>().SaveUpgradeCriticalMultiplier(newUpgradeCriticalMultiplierValue);
                    return;

                case "ExcelentProbability":
                    var previousExcelentProbability = ServiceLocator.Instance.GetService<UpgradesSystem>().GetUpgradeExcelentProbability();
                    var newUpgradeExcelentProbabilityValue = previousExcelentProbability + _nodeToSpawnConfiguration.StatsToAdd;
                    ServiceLocator.Instance.GetService<UpgradesSystem>().SaveUpgradeExcelentProbability(newUpgradeExcelentProbabilityValue);
                    return;

                case "ExcelentMultiplier":
                    var previousExcelentMultiplier = ServiceLocator.Instance.GetService<UpgradesSystem>().GetUpgradeExcelentMultiplier();
                    var newUpgradeExcelentMultiplierValue = previousExcelentMultiplier + _nodeToSpawnConfiguration.StatsToAdd;
                    ServiceLocator.Instance.GetService<UpgradesSystem>().SaveUpgradeExcelentMultiplier(newUpgradeExcelentMultiplierValue);
                    return;

                case "HpAbsorbProbability":
                    var previousHpAbsorbProbability = ServiceLocator.Instance.GetService<UpgradesSystem>().GetUpgradeHpAbsorbProbability();
                    var newUpgradeHpAbsorbProbabilityValue = previousHpAbsorbProbability + _nodeToSpawnConfiguration.StatsToAdd;
                    ServiceLocator.Instance.GetService<UpgradesSystem>().SaveUpgradeHpAbsorbProbability(newUpgradeHpAbsorbProbabilityValue);
                    return;

                case "HpAbsorbDenominator":
                    var previousHpAbsorbDenominator = ServiceLocator.Instance.GetService<UpgradesSystem>().GetUpgradeHpAbsorbDenominator();
                    var newUpgradeHpAbsorbDenominatorValue = previousHpAbsorbDenominator + _nodeToSpawnConfiguration.StatsToAdd;
                    ServiceLocator.Instance.GetService<UpgradesSystem>().SaveUpgradeHpAbsorbDenominator(newUpgradeHpAbsorbDenominatorValue);
                    return;

                case "MultipleHitsProbability":
                    var previousMultipleHitsProbability = ServiceLocator.Instance.GetService<UpgradesSystem>().GetUpgradeMultipleHitsProbability();
                    var newUpgradeMultipleHitsProbabilityValue = previousMultipleHitsProbability + _nodeToSpawnConfiguration.StatsToAdd;
                    ServiceLocator.Instance.GetService<UpgradesSystem>().SaveUpgradeMultipleHitsProbability(newUpgradeMultipleHitsProbabilityValue);
                    return;

                case "NumberOfHits":
                    var previousNumberOfHits = ServiceLocator.Instance.GetService<UpgradesSystem>().GetUpgradeNumberOfHits();
                    var newUpgradeNumberOfHitsValue = previousNumberOfHits + _nodeToSpawnConfiguration.StatsToAdd;
                    ServiceLocator.Instance.GetService<UpgradesSystem>().SaveUpgradeNumberOfHits(newUpgradeNumberOfHitsValue);
                    return;

                case "Energy":
                    var previousEnergy = ServiceLocator.Instance.GetService<UpgradesSystem>().GetUpgradeEnergy();
                    var newUpgradeEnergyValue = previousEnergy + _nodeToSpawnConfiguration.StatsToAdd;
                    ServiceLocator.Instance.GetService<UpgradesSystem>().SaveUpgradeEnergy(newUpgradeEnergyValue);

                    var energyNodeActivedEventData = new EnergyNodeActivedEventData(_nodeToSpawnConfiguration.StatsToAdd, GetInstanceID());
                    ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(energyNodeActivedEventData);
                    return;
            }
        }

        public void Process(EventData eventData)
        {
            if(eventData.EventId == EventIds.UpgradeNodeActived)
            {
                var upgradeNodeActivedEventData = (UpgradeNodeActivedEventData)eventData;

                if(upgradeNodeActivedEventData.NodeName == _nodeToSpawnConfiguration.NodeId)
                {
                    ActiveThisNode();
                }
            }

            if(eventData.EventId == EventIds.UpgradeCheckForAvailability)
            {
                CheckForAvailabilityAndActivation();
            }
        }
    }
}