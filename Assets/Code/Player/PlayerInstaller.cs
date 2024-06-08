using Assets.Code.Common.Events;
using Assets.Code.Common.SwordsData;
using Assets.Code.Core;
using UnityEngine;

namespace Assets.Code.Player
{
    public class PlayerInstaller : MonoBehaviour, EventObserver
    {
        [SerializeField] private PlayerToSpawnConfiguration _playerConfiguration;
        private PlayerBuilder _playerBuilder;

        private TrailRenderer _swordTrailRenderer;
        private string _swordId;
        private int _swordAttack;
        private int _swordHp;
        private float _swordCriticalMultiplier;
        private float _swordCriticalProbability;
        private float _swordExcelentMultiplier;
        private float _swordExcelentProbability;
        private float _swordHpAbsorbDenominator;
        private float _swordHpAbsorbProbability;
        private float _swordMultipleHitsProbability;
        private int _swordNumberOfHits;

        private void Start()
        {
            ServiceLocator.Instance.GetService<EventQueue>().Subscribe(EventIds.SwordEquiped, this);
            ServiceLocator.Instance.GetService<EventQueue>().Subscribe(EventIds.SwordEquippedLevelUp, this);
            var playerFactory = ServiceLocator.Instance.GetService<PlayerFactory>();
            _playerBuilder = playerFactory.Create(_playerConfiguration.PlayerId.Value)
                                          .WithLevel()
                                          .WithUpgradesStats()
                                          .WithConfiguration(_playerConfiguration);
        }


        private void OnDestroy()
        {
            ServiceLocator.Instance.GetService<EventQueue>().Unsubscribe(EventIds.SwordEquiped, this);
            ServiceLocator.Instance.GetService<EventQueue>().Unsubscribe(EventIds.SwordEquippedLevelUp, this);
        }


        public void SpawnUserShip()
        {
            _playerBuilder.WithTrailStats(_swordId, _swordHp, _swordAttack, _swordCriticalMultiplier, _swordCriticalProbability,
                                          _swordExcelentMultiplier, _swordExcelentProbability, _swordHpAbsorbProbability,
                                          _swordHpAbsorbDenominator, _swordMultipleHitsProbability, _swordNumberOfHits,
                                          _swordTrailRenderer)
                                          .WithLevel()
                                          .WithUpgradesStats();
            _playerBuilder.Build();
        }

        public void Process(EventData eventData)
        {

            if (eventData.EventId == EventIds.SwordEquiped)
            {
                var swordEquipedEventData = (SwordEquipedEventData)eventData;

                _swordTrailRenderer = swordEquipedEventData._trailRenderer;
                _swordAttack = swordEquipedEventData._attack;
                _swordHp = swordEquipedEventData._hp;
                _swordCriticalMultiplier = swordEquipedEventData._criticalMultiplier;
                _swordCriticalProbability = swordEquipedEventData._criticalProbability;
                _swordExcelentMultiplier = swordEquipedEventData._excelentMultiplier;
                _swordExcelentProbability = swordEquipedEventData._excelentProbability;
                _swordHpAbsorbDenominator = swordEquipedEventData._hpAbsorbDenominator;
                _swordHpAbsorbProbability = swordEquipedEventData._hpAbsorbProbability;
                _swordMultipleHitsProbability = swordEquipedEventData._multipleHitsProbability;
                _swordNumberOfHits = swordEquipedEventData._numberOfHits;
                _swordId = swordEquipedEventData._id;


                SpawnUserShip();
            }



            if (eventData.EventId == EventIds.SwordEquippedLevelUp)
            {
                var swordEquippedLevelUpEventData = (SwordEquippedLevelUpEventData)eventData;
                if (ServiceLocator.Instance.GetService<SwordEquippedSystem>().GetSwordEquipped() == swordEquippedLevelUpEventData.Id)
                {
                    _swordAttack = swordEquippedLevelUpEventData.Attack;
                    _swordHp = swordEquippedLevelUpEventData.Hp;
                    _swordCriticalMultiplier = swordEquippedLevelUpEventData.CriticalMultiplier;
                    _swordCriticalProbability = swordEquippedLevelUpEventData.CriticalProbability;
                    _swordExcelentMultiplier = swordEquippedLevelUpEventData.ExcelentMultiplier;
                    _swordExcelentProbability = swordEquippedLevelUpEventData.ExcelentProbability;
                    _swordHpAbsorbDenominator = swordEquippedLevelUpEventData.HpAbsorbDenominator;
                    _swordHpAbsorbProbability = swordEquippedLevelUpEventData.HpAbsorbProbability;
                    _swordMultipleHitsProbability = swordEquippedLevelUpEventData.MultipleHitsProbability;
                    _swordNumberOfHits = swordEquippedLevelUpEventData.NumberOfHits;
                }

            }
        }
    }
}