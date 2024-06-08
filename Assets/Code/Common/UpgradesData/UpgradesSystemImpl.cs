using Assets.Code.Core.DataStorage;

namespace Assets.Code.Common.UpgradesData
{
    public class UpgradesSystemImpl : UpgradesSystem
    {
        private readonly DataStore _dataStore;
        private const string _attackData = "AttackData";
        private const string _hpData = "HpData";
        private const string _criticalMultiplierData = "CriticalMultiplierData";
        private const string _criticalProbabilityData = "CriticalProbabilityData";
        private const string _excelentMultiplierData = "ExcelentMultiplierData";
        private const string _excelentProbabilityData = "ExcelentProbabilityData";
        private const string _hpAbsorbDenominatorData = "HpAbsorbDenominatorData";
        private const string _hpAbsorbProbabilityData = "HpAbsorbProbabilityData";
        private const string _multipleHitsProbabilityData = "MultipleHitsProbabilityData";
        private const string _numberOfHitsData = "NumberOfHitsData";
        private const string _energyData = "EnergyData";



        public UpgradesSystemImpl(DataStore dataStore)
        {
            _dataStore = dataStore;
        }



        public float GetUpgradeAttack()
        {
            var userData = _dataStore.GetData<UserData>(_attackData)
                        ?? new UserData();
            return userData.UpgradesAttack;
        }
        public void SaveUpgradeAttack(float upgradeAttack)
        {
            var userData = new UserData { UpgradesAttack = upgradeAttack };
            _dataStore.SetData(userData, _attackData);
        }



        public float GetUpgradeHp()
        {
            var userData = _dataStore.GetData<UserData>(_hpData)
                        ?? new UserData();
            return userData.UpgradesHp;
        }
        public void SaveUpgradeHp(float upgradeHp)
        {
            var userData = new UserData { UpgradesHp = upgradeHp };
            _dataStore.SetData(userData, _hpData);
        }



        public float GetUpgradeCriticalMultiplier()
        {
            var userData = _dataStore.GetData<UserData>(_criticalMultiplierData)
                        ?? new UserData();
            return userData.UpgradesCriticalMultiplier;
        }
        public void SaveUpgradeCriticalMultiplier(float upgradeCriticalMultiplier)
        {
            var userData = new UserData { UpgradesCriticalMultiplier = upgradeCriticalMultiplier };
            _dataStore.SetData(userData, _criticalMultiplierData);
        }



        public float GetUpgradeCriticalProbability()
        {
            var userData = _dataStore.GetData<UserData>(_criticalProbabilityData)
                        ?? new UserData();
            return userData.UpgradesCriticalProbability;
        }
        public void SaveUpgradeCriticalProbability(float upgradeCriticalProbability)
        {
            var userData = new UserData { UpgradesCriticalProbability = upgradeCriticalProbability };
            _dataStore.SetData(userData, _criticalProbabilityData);
        }



        public float GetUpgradeExcelentMultiplier()
        {
            var userData = _dataStore.GetData<UserData>(_excelentMultiplierData)
                        ?? new UserData();
            return userData.UpgradesExcelentMultiplier;
        }
        public void SaveUpgradeExcelentMultiplier(float upgradeExcelentMultiplier)
        {
            var userData = new UserData { UpgradesExcelentMultiplier = upgradeExcelentMultiplier };
            _dataStore.SetData(userData, _excelentMultiplierData);
        }



        public float GetUpgradeExcelentProbability()
        {
            var userData = _dataStore.GetData<UserData>(_excelentProbabilityData)
                        ?? new UserData();
            return userData.UpgradesExcelentProbability;
        }
        public void SaveUpgradeExcelentProbability(float upgradeExcelentProbability)
        {
            var userData = new UserData { UpgradesExcelentProbability = upgradeExcelentProbability };
            _dataStore.SetData(userData, _excelentProbabilityData);
        }



        public float GetUpgradeHpAbsorbDenominator()
        {
            var userData = _dataStore.GetData<UserData>(_hpAbsorbDenominatorData)
                        ?? new UserData();
            return userData.UpgradesHpAbsorbDenominator;
        }
        public void SaveUpgradeHpAbsorbDenominator(float upgradeHpAbsorbDenominator)
        {
            var userData = new UserData { UpgradesHpAbsorbDenominator = upgradeHpAbsorbDenominator };
            _dataStore.SetData(userData, _hpAbsorbDenominatorData);
        }



        public float GetUpgradeHpAbsorbProbability()
        {
            var userData = _dataStore.GetData<UserData>(_hpAbsorbProbabilityData)
                        ?? new UserData();
            return userData.UpgradesHpAbsorbProbability;
        }
        public void SaveUpgradeHpAbsorbProbability(float upgradeHpAbsorbProbability)
        {
            var userData = new UserData { UpgradesHpAbsorbProbability = upgradeHpAbsorbProbability };
            _dataStore.SetData(userData, _hpAbsorbProbabilityData);
        }



        public float GetUpgradeMultipleHitsProbability()
        {
            var userData = _dataStore.GetData<UserData>(_multipleHitsProbabilityData)
                        ?? new UserData();
            return userData.UpgradesMultipleHitsProbability;
        }
        public void SaveUpgradeMultipleHitsProbability(float upgradeMultipleHitsProbability)
        {
            var userData = new UserData { UpgradesMultipleHitsProbability = upgradeMultipleHitsProbability };
            _dataStore.SetData(userData, _multipleHitsProbabilityData);
        }



        public float GetUpgradeNumberOfHits()
        {
            var userData = _dataStore.GetData<UserData>(_numberOfHitsData)
                        ?? new UserData();
            return userData.UpgradesNumberOfHits;
        }
        public void SaveUpgradeNumberOfHits(float upgradeNumberOfHits)
        {
            var userData = new UserData { UpgradesNumberOfHits = upgradeNumberOfHits };
            _dataStore.SetData(userData, _numberOfHitsData);
        }
        
        
        
        public float GetUpgradeEnergy()
        {
            var userData = _dataStore.GetData<UserData>(_energyData)
                        ?? new UserData();
            return userData.UpgradesEnergy;
        }
        public void SaveUpgradeEnergy(float upgradeEnergy)
        {
            var userData = new UserData { UpgradesEnergy = upgradeEnergy };
            _dataStore.SetData(userData, _energyData);
        }
    }
}