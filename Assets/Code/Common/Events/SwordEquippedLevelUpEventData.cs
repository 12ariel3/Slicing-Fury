
namespace Assets.Code.Common.Events
{
    public class SwordEquippedLevelUpEventData : EventData
    {
        public readonly string Id;
        public readonly int TrailUpgradeValue;
        public readonly int Level;
        public readonly int Attack;
        public readonly int Hp;
        public readonly float CriticalProbability;
        public readonly float ExcelentProbability;
        public readonly float CriticalMultiplier;
        public readonly float ExcelentMultiplier;
        public readonly float MultipleHitsProbability;
        public readonly int NumberOfHits;
        public readonly float HpAbsorbDenominator;
        public readonly float HpAbsorbProbability;
        public readonly int InstanceId;


        public SwordEquippedLevelUpEventData(string swordName, int trailUpgradeValue, int level, int swordAttack, int swordHp,
                                             float swordCriticalProbability, float swordExcelentProbability, float swordCriticalDmg,
                                             float swordExcelentDmg, float swordHitProbability, int swordNumberOfHits, float swordHpAbsorbDenominator,
                                             float swordHpAbsorbProbability, int instanceId) : base(EventIds.SwordEquippedLevelUp)
        {
            Id = swordName;
            TrailUpgradeValue = trailUpgradeValue;
            Level = level;
            Attack = swordAttack;
            Hp = swordHp;
            CriticalProbability = swordCriticalProbability;
            ExcelentProbability = swordExcelentProbability;
            CriticalMultiplier = swordCriticalDmg;
            ExcelentMultiplier = swordExcelentDmg;
            MultipleHitsProbability = swordHitProbability;
            NumberOfHits = swordNumberOfHits;
            HpAbsorbDenominator = swordHpAbsorbDenominator;
            HpAbsorbProbability = swordHpAbsorbProbability;
            InstanceId = instanceId;
        }
    }
}