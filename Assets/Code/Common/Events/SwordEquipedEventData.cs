using UnityEngine;

namespace Assets.Code.Common.Events
{
    public class SwordEquipedEventData : EventData
    {
        public readonly Sprite _swordSprite;
        public readonly int _swordUpgradeValue;
        public readonly string _id;
        public readonly int _level;
        public readonly int _attack;
        public readonly int _hp;
        public readonly float _criticalProbability;
        public readonly float _excelentProbability;
        public readonly float _criticalMultiplier;
        public readonly float _excelentMultiplier;
        public readonly float _multipleHitsProbability;
        public readonly int _numberOfHits;
        public readonly float _hpAbsorbDenominator;
        public readonly float _hpAbsorbProbability;
        public readonly Color _deepBackground;
        public readonly Color _background;
        public readonly Color _iconBackground;
        public readonly Color _nameColor;
        public readonly Color _levelColor;
        public readonly TrailRenderer _trailRenderer;
        public readonly int InstanceId;


        public SwordEquipedEventData(Sprite swordSprite, int swordUpgradeValue, string swordName, int swordLevel, int swordAttack, int swordHp,
                                     float swordCriticalProbability, float swordExcelentProbability, float swordCriticalDmg, float swordExcelentDmg,
                                     float swordHitProbability, int swordNumberOfHits, float swordHpAbsorbDenominator,
                                     float swordHpAbsorbProbability, Color deepBackground, Color background, Color iconBackground, Color nameColor,
                                     Color levelColor, TrailRenderer trailRenderer, int instanceId) : base(EventIds.SwordEquiped)
        {
            _swordSprite = swordSprite;
            _swordUpgradeValue = swordUpgradeValue;
            _id = swordName;
            _level = swordLevel;
            _attack = swordAttack;
            _hp = swordHp;
            _criticalProbability = swordCriticalProbability;
            _excelentProbability = swordExcelentProbability;
            _criticalMultiplier = swordCriticalDmg;
            _excelentMultiplier = swordExcelentDmg;
            _multipleHitsProbability = swordHitProbability;
            _numberOfHits = swordNumberOfHits;
            _hpAbsorbDenominator = swordHpAbsorbDenominator;
            _hpAbsorbProbability = swordHpAbsorbProbability;
            _deepBackground = deepBackground;
            _background = background;
            _iconBackground = iconBackground;
            _nameColor = nameColor;
            _levelColor = levelColor;
            _trailRenderer = trailRenderer;
            InstanceId = instanceId;
        }
    }
}