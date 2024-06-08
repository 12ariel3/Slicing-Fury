using Assets.Code.Common.Events;
using Assets.Code.Core;
using TMPro;
using UnityEngine;

namespace Assets.Code.UI
{
    public class StatsPanelView : MonoBehaviour, EventObserver
    {
        [SerializeField] private TextMeshProUGUI _attack;
        [SerializeField] private TextMeshProUGUI _hp;
        [SerializeField] private TextMeshProUGUI _criticalProbability;
        [SerializeField] private TextMeshProUGUI _excelentProbability;
        [SerializeField] private TextMeshProUGUI _criticalDmg;
        [SerializeField] private TextMeshProUGUI _excelentDmg;
        [SerializeField] private TextMeshProUGUI _hitProbability;
        [SerializeField] private TextMeshProUGUI _numberOfHits;
        [SerializeField] private TextMeshProUGUI _hpAbsorbDenominator;
        [SerializeField] private TextMeshProUGUI _hpAbsorbProbability;

        private void Start()
        {
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Subscribe(EventIds.PlayerSendFinalStatsValue, this);
        }

        private void OnDestroy()
        {
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Unsubscribe(EventIds.PlayerSendFinalStatsValue, this);
        }


        private void SetFinalStatsOnPanel(int attackValue, int hpValue, float criticalMultiplier, float criticalProbability,
                                         float excelentMultiplier, float excelentProbability, float hpAbsorbProbability,
                                         float hpAbsorbDenominator, float multipleHitsProbability, int numberOfHits)
        {
            _attack.SetText(attackValue.ToString());
            _hp.SetText(hpValue.ToString());
            _criticalProbability.SetText(criticalProbability.ToString("f1") + " %");
            _excelentProbability.SetText(excelentProbability.ToString("f1") + " %");
            _criticalDmg.SetText(criticalMultiplier.ToString("f1"));
            _excelentDmg.SetText(excelentMultiplier.ToString("f1"));
            _hitProbability.SetText(multipleHitsProbability.ToString("f1") + " %");
            _numberOfHits.SetText(numberOfHits.ToString());
            _hpAbsorbDenominator.SetText(hpAbsorbDenominator.ToString("f1"));
            _hpAbsorbProbability.SetText(hpAbsorbProbability.ToString("f1") + " %");
        }


        public void Process(EventData eventData)
        {

            if (eventData.EventId == EventIds.PlayerSendFinalStatsValue)
            {
                var playerSendFinalStatsEventData = (PlayerSendFinalStatsEventData)eventData;

                SetFinalStatsOnPanel(playerSendFinalStatsEventData.AttackValue, playerSendFinalStatsEventData.HpValue,
                            playerSendFinalStatsEventData.CriticalMultiplier, playerSendFinalStatsEventData.CriticalProbability,
                            playerSendFinalStatsEventData.ExcelentMultiplier, playerSendFinalStatsEventData.ExcelentProbability,
                            playerSendFinalStatsEventData.HpAbsorbProbability, playerSendFinalStatsEventData.HpAbsorbDenominator,
                            playerSendFinalStatsEventData.MultipleHitsProbability, playerSendFinalStatsEventData.NumberOfHits);

                
            }
        }
    }
}