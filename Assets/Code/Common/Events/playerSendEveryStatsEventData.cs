namespace Assets.Code.Common.Events
{
    public class playerSendEveryStatsEventData : EventData
    {
        public readonly int CharacterAttackValue;
        public readonly int CharacterHpValue;
        public readonly float CharacterCriticalMultiplier;
        public readonly float CharacterCriticalProbability;
        public readonly float CharacterExcelentMultiplier;
        public readonly float CharacterExcelentProbability;
        public readonly float CharacterHpAbsorbProbability;
        public readonly float CharacterHpAbsorbDenominator;
        public readonly float CharacterMultipleHitsProbability;
        public readonly int CharacterNumberOfHits;

        public readonly int SwordAttackValue;
        public readonly int SwordHpValue;
        public readonly float SwordCriticalMultiplier;
        public readonly float SwordCriticalProbability;
        public readonly float SwordExcelentMultiplier;
        public readonly float SwordExcelentProbability;
        public readonly float SwordHpAbsorbProbability;
        public readonly float SwordHpAbsorbDenominator;
        public readonly float SwordMultipleHitsProbability;
        public readonly int SwordNumberOfHits;

        public readonly float UpgradesAttackValue;
        public readonly float UpgradesHpValue;
        public readonly float UpgradesCriticalMultiplier;
        public readonly float UpgradesCriticalProbability;
        public readonly float UpgradesExcelentMultiplier;
        public readonly float UpgradesExcelentProbability;
        public readonly float UpgradesHpAbsorbProbability;
        public readonly float UpgradesHpAbsorbDenominator;
        public readonly float UpgradesMultipleHitsProbability;
        public readonly float UpgradesNumberOfHits;
        public readonly int InstanceId;

        public playerSendEveryStatsEventData(int characterAttackValue, int characterHpValue, float characterCriticalMultiplier,
                                         float characterCriticalProbability, float characterExcelentMultiplier,
                                         float characterExcelentProbability, float characterHpAbsorbProbability,
                                         float characterHpAbsorbDenominator, float characterMultipleHitsProbability, int characterNumberOfHits,

                                         int swordAttackValue, int swordHpValue, float swordCriticalMultiplier, float swordCriticalProbability,
                                         float swordExcelentMultiplier, float swordExcelentProbability, float swordHpAbsorbProbability,
                                         float swordHpAbsorbDenominator, float swordMultipleHitsProbability, int swordNumberOfHits,

                                         float upgradesAttackValue, float upgradesHpValue, float upgradesCriticalMultiplier,
                                         float upgradesCriticalProbability, float upgradesExcelentMultiplier,
                                         float upgradesExcelentProbability, float upgradesHpAbsorbProbability,
                                         float upgradesHpAbsorbDenominator, float upgradesMultipleHitsProbability, float upgradesNumberOfHits,
                                         int instanceId) : base(EventIds.PlayerSendEveryStatsValue)
        {
            CharacterAttackValue = characterAttackValue;
            CharacterHpValue = characterHpValue;
            CharacterCriticalMultiplier = characterCriticalMultiplier;
            CharacterCriticalProbability = characterCriticalProbability;
            CharacterExcelentMultiplier = characterExcelentMultiplier;
            CharacterExcelentProbability = characterExcelentProbability;
            CharacterHpAbsorbProbability = characterHpAbsorbProbability;
            CharacterHpAbsorbDenominator = characterHpAbsorbDenominator;
            CharacterMultipleHitsProbability = characterMultipleHitsProbability;
            CharacterNumberOfHits = characterNumberOfHits;

            SwordAttackValue = swordAttackValue;
            SwordHpValue = swordHpValue;
            SwordCriticalMultiplier = swordCriticalMultiplier;
            SwordCriticalProbability = swordCriticalProbability;
            SwordExcelentMultiplier = swordExcelentMultiplier;
            SwordExcelentProbability = swordExcelentProbability;
            SwordHpAbsorbProbability = swordHpAbsorbProbability;
            SwordHpAbsorbDenominator = swordHpAbsorbDenominator;
            SwordMultipleHitsProbability = swordMultipleHitsProbability;
            SwordNumberOfHits = swordNumberOfHits;

            UpgradesAttackValue = upgradesAttackValue;
            UpgradesHpValue = upgradesHpValue;
            UpgradesCriticalMultiplier = upgradesCriticalMultiplier;
            UpgradesCriticalProbability = upgradesCriticalProbability;
            UpgradesExcelentMultiplier = upgradesExcelentMultiplier;
            UpgradesExcelentProbability = upgradesExcelentProbability;
            UpgradesHpAbsorbProbability = upgradesHpAbsorbProbability;
            UpgradesHpAbsorbDenominator = upgradesHpAbsorbDenominator;
            UpgradesMultipleHitsProbability = upgradesMultipleHitsProbability;
            UpgradesNumberOfHits = upgradesNumberOfHits;

            InstanceId = instanceId;
        }
    }
}