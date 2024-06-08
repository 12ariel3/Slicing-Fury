
namespace Assets.Code.Common.Events
{
    public class PlayerSendFinalStatsEventData : EventData
    {
        public readonly int AttackValue;
        public readonly int HpValue;
        public readonly float CriticalMultiplier;
        public readonly float CriticalProbability;
        public readonly float ExcelentMultiplier;
        public readonly float ExcelentProbability;
        public readonly float HpAbsorbProbability;
        public readonly float HpAbsorbDenominator;
        public readonly float MultipleHitsProbability;
        public readonly int NumberOfHits;
        public readonly int InstanceId;

        public PlayerSendFinalStatsEventData(int attackValue, int hpValue, float criticalMultiplier, float criticalProbability,
                                         float excelentMultiplier, float excelentProbability, float hpAbsorbProbability,
                                         float hpAbsorbDenominator, float multipleHitsProbability, int numberOfHits,
                                         int instanceId) : base(EventIds.PlayerSendFinalStatsValue)
        {
            AttackValue = attackValue;
            HpValue = hpValue;
            CriticalMultiplier = criticalMultiplier;
            CriticalProbability = criticalProbability; 
            ExcelentMultiplier = excelentMultiplier;
            ExcelentProbability = excelentProbability;
            HpAbsorbProbability = hpAbsorbProbability;
            HpAbsorbDenominator = hpAbsorbDenominator;
            MultipleHitsProbability = multipleHitsProbability;
            NumberOfHits = numberOfHits;
            InstanceId = instanceId;
        }
    }
}