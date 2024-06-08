namespace Assets.Code.Common.UpgradesData
{
    public interface UpgradesSystem
    {
        float GetUpgradeAttack();
        public void SaveUpgradeAttack(float upgradeAttack);
        float GetUpgradeHp();
        public void SaveUpgradeHp(float upgradeHp);
        float GetUpgradeCriticalMultiplier();
        public void SaveUpgradeCriticalMultiplier(float upgradeCriticalMultiplier);
        float GetUpgradeCriticalProbability();
        public void SaveUpgradeCriticalProbability(float upgradeCriticalProbability);
        float GetUpgradeExcelentMultiplier();
        public void SaveUpgradeExcelentMultiplier(float upgradeExcelentMultiplier);
        float GetUpgradeExcelentProbability();
        public void SaveUpgradeExcelentProbability(float upgradeExcelentProbability);
        float GetUpgradeHpAbsorbDenominator();
        public void SaveUpgradeHpAbsorbDenominator(float upgradeHpAbsorbDenominator);
        float GetUpgradeHpAbsorbProbability();
        public void SaveUpgradeHpAbsorbProbability(float upgradeHpAbsorbProbability);
        float GetUpgradeMultipleHitsProbability();
        public void SaveUpgradeMultipleHitsProbability(float upgradeMultipleHitsProbability);
        float GetUpgradeNumberOfHits();
        public void SaveUpgradeNumberOfHits(float upgradeNumberOfHits);
        float GetUpgradeEnergy();
        public void SaveUpgradeEnergy(float upgradeEnergy);
    }
}