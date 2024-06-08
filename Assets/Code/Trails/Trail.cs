using Assets.Code.Common.Level;
using Assets.Code.Core;
using UnityEngine;

namespace Assets.Code.Trails
{
        
    public class Trail : MonoBehaviour
    {
        [SerializeField] private TrailToSpawnConfiguration _trailConfiguration;

        private int _trailUpgradeValue;
        private int _trailUnlockScoreCost;
        private int _trailUnlockGemsCost;
        private string _id;
        private TrailRenderer _trailRenderer;
        private Sprite _swordSprite;
        private int _level;
        private int _attack;
        private int _hp;
        private float _criticalMultiplier;
        private float _criticalProbability;
        private float _excelentMultiplier;
        private float _excelentProbability;
        private float _hpAbsorbDenominator;
        private float _hpAbsorbProbability;
        private int _numberOfHits;
        private float _multipleHitsProbability;
        private bool _isOverFiftyLevel;
        private Color _deepBackground;
        private Color _background;
        private Color _iconBackground;
        private Color _nameColor;
        private Color _levelColor;


        public int TrailUpgradeValue => _trailUpgradeValue;
        public int TrailUnlockScoreCost => _trailUnlockScoreCost;
        public int TrailUnlockGemsCost => _trailUnlockGemsCost;
        public string Id => _id;
        public TrailRenderer TrailRenderer => _trailRenderer;
        public Sprite SwordSprite => _swordSprite;
        public int Level => _level;
        public int Attack => _attack;
        public int HP => _hp;
        public float CriticalMultiplier => _criticalMultiplier;
        public float CriticalProbability => _criticalProbability;
        public float ExcelentMultiplier => _excelentMultiplier;
        public float ExcelentProbability => _excelentProbability;
        public float HpAbsorbDenominator => _hpAbsorbDenominator;
        public float HpAbsorbProbability => _hpAbsorbProbability;
        public int NumberOfHits => _numberOfHits;
        public float MultipleHitsProbability => _multipleHitsProbability;
        public Color DeepBackground => _deepBackground;
        public Color Background => _background;
        public Color IconBackground => _iconBackground;
        public Color NameColor => _nameColor;
        public Color LevelColor => _levelColor;


        private void Start()
        {
            _trailUnlockScoreCost = _trailConfiguration.TrailUnlockScoreCost;
            _trailUnlockGemsCost = _trailConfiguration.TrailUnlockGemsCost;
            _id = _trailConfiguration.TrailId.Value;
            _trailRenderer = _trailConfiguration.TrailRenderer;
            _swordSprite = _trailConfiguration.SwordImage;
            _deepBackground = _trailConfiguration.DeepBackground;
            _background = _trailConfiguration.Background;
            _iconBackground = _trailConfiguration.IconBackground;
            _nameColor = _trailConfiguration.NameColor;
            _levelColor = _trailConfiguration.LevelColor;
            _level = ServiceLocator.Instance.GetService<SwordsLevelSystem>().GetLevel(Id);
            SetStatsCalculation();
            _numberOfHits = 1;
            _isOverFiftyLevel = false;
            if (_level >= 50)
            {
                OverFiftyLevel(true);
            }
        }


        public void LevelUp(int level)
        {
            _level = level;
            SetStatsCalculation();

            if (_level >= 50)
            {
                OverFiftyLevel(true);
            }
        }

        private void SetStatsCalculation()
        {
            _trailUpgradeValue = Mathf.FloorToInt((10 * _level) * (1 + (_trailConfiguration.TrailUpgradeBaseValue * (_level / 10f))));
            _attack = Mathf.FloorToInt(((_trailConfiguration.TrailBaseAttack * (_level/2f) * (_level/4f)) / 100f) + 5);
            _hp = Mathf.FloorToInt(((_trailConfiguration.TrailBaseHp * (_level / 2f) * (_level / 4f)) / 100f) + 10);
            _criticalMultiplier = _trailConfiguration.TrailCriticalMultiplier * ((_level /2) /50);
            _criticalProbability = _trailConfiguration.TrailCriticalProbability * _level;
            _excelentMultiplier = _trailConfiguration.TrailExcelentMultiplier * ((_level / 2) / 50);
            _excelentProbability = _trailConfiguration.TrailExcelentProbability * _level;
            _multipleHitsProbability = _trailConfiguration.TrailMultipleHitsProbability * _level;
            _hpAbsorbProbability = _trailConfiguration.TrailHpAbsorbProbability * _level;
            if (_trailConfiguration.TrailHpAbsorbDenominator <= 0)
            {
                _hpAbsorbDenominator = 0;
            }
            else
            {
                _hpAbsorbDenominator = _attack /(20f - (_trailConfiguration.TrailHpAbsorbDenominator * ((_level / 2) / 50)));
            }
        }

        private void OverFiftyLevel(bool isOverFifty)
        {
            if (_isOverFiftyLevel != isOverFifty)
            {
                _numberOfHits++;
                _isOverFiftyLevel = true;
            }
        }
    }
}