using UnityEngine;

namespace Assets.Code.Trails
{
    public class TrailStatsController : MonoBehaviour
    {
        private int _level;
        private int _baseAttack;
        private int _baseMaxHp;
        private int _maxHp;
        private int _attack;
        private float _baseCriticalMultiplier;
        private float _baseCriticalProbability;
        private float _baseExcelentMultiplier;
        private float _baseExcelentProbability;
        private float _criticalMultiplier;
        private float _criticalProbability;
        private float _excelentMultiplier;
        private float _excelentProbability;
        private float _hpAbsorbDenominator;
        private float _hpAbsorbProbability;
        private float _finalCriticalMultiplier;
        private float _finalCriticalProbability;
        private float _finalExcelentMultiplier;
        private float _finalExcelentProbability;
        private int _numberOfHits;
        private float _multipleHitsProbability;
        private float _baseMultipleHitsProbability;
        private float _finalMultipleHitsProbability;
        private bool _isOverFiftyLevel;

        public int Attack => _attack;
        public int Level => _level;
        public int MaxHp => _maxHp;
        public float BaseCriticalMultiplier => _baseCriticalMultiplier;
        public float BaseCriticalProbability => _baseCriticalProbability;
        public float BaseExcelentMultiplier => _baseExcelentMultiplier;
        public float BaseExcelentProbability => _baseExcelentProbability;
        public float CriticalMultiplier => _criticalMultiplier;
        public float CriticalProbability => _criticalProbability;
        public float ExcelentMultiplier => _excelentMultiplier;
        public float ExcelentProbability => _excelentProbability;
        public float HpAbsorbDenominator => _hpAbsorbDenominator;
        public float HpAbsorbProbability => _hpAbsorbProbability;
        public float FinalCriticalMultiplier => _finalCriticalMultiplier;
        public float FinalCriticalProbability => _finalCriticalProbability;
        public float FinalExcelentMultiplier => _finalExcelentMultiplier;
        public float FinalExcelentProbability => _finalExcelentProbability;
        public int NumberOfHits => _numberOfHits;
        public float MultipleHitsProbability => _multipleHitsProbability;
        public float BaseMultipleHitsProbability => _baseMultipleHitsProbability;
        public float FinalMultipleHitsProbability => _finalMultipleHitsProbability;


        public void Configure(int baseMaxHp, int level, int baseAttack, float criticalMultiplier, float criticalProbability,
                             float excelentMultiplier, float excelentProbability, float hpAbsorbDenominator, float hpAbsorbProbability,
                             int numberOfHits, float multipleHitsProbability)
        {
            _level = level;
            _baseAttack = baseAttack;
            _baseMaxHp = baseMaxHp;
            _maxHp = Mathf.FloorToInt(((_baseMaxHp * _level * _level) / 100f) + 10);
            _attack = Mathf.FloorToInt(((_baseAttack * _level * _level) / 100f) + 5);
            _criticalMultiplier = criticalMultiplier;
            _criticalProbability = criticalProbability;
            _excelentMultiplier = excelentMultiplier;
            _excelentProbability = excelentProbability;
            _hpAbsorbDenominator = hpAbsorbDenominator;
            _hpAbsorbProbability = hpAbsorbProbability;
            _baseCriticalMultiplier = 2;
            _baseCriticalProbability = (_level / 10);
            _baseExcelentMultiplier = 4;
            _baseExcelentProbability = (_level / 10);
            _finalCriticalMultiplier = _baseCriticalMultiplier + _criticalMultiplier;
            _finalCriticalProbability = _baseCriticalProbability + _criticalProbability;
            _finalExcelentMultiplier = _baseExcelentMultiplier + _excelentMultiplier;
            _finalExcelentProbability = _baseExcelentProbability + _excelentProbability;
            _numberOfHits = numberOfHits;
            _multipleHitsProbability = multipleHitsProbability;
            _baseMultipleHitsProbability = (_level / 5);
            _finalMultipleHitsProbability = _multipleHitsProbability + _baseMultipleHitsProbability;
        }



        public void LevelUp(int level)
        {
            _level = level;
            _attack = Mathf.FloorToInt(((_baseAttack * _level * _level) / 100f) + 5);
            _baseCriticalProbability = (_level / 20);
            _baseExcelentProbability = (_level / 50);
            _finalCriticalMultiplier = _baseCriticalMultiplier + _criticalMultiplier;
            _finalCriticalProbability = _baseCriticalProbability + _criticalProbability;
            _finalExcelentMultiplier = _baseExcelentMultiplier + _excelentMultiplier;
            _finalExcelentProbability = _baseExcelentProbability + _excelentProbability;
            _baseMultipleHitsProbability = (_level / 5);
            _finalMultipleHitsProbability = _multipleHitsProbability + _baseMultipleHitsProbability;
            if(_level >= 50) 
            {
                OverFiftyLevel(true);
            }
        }

        private void OverFiftyLevel(bool isOverFifty)
        {
            if(_isOverFiftyLevel != isOverFifty)
            {
                _numberOfHits++;
                _isOverFiftyLevel = true;
            }
        }
    }
}