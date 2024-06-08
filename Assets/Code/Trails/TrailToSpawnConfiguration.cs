using UnityEngine;

namespace Assets.Code.Trails
{
    [CreateAssetMenu(menuName = "Trail/TrailToSpawnConfiguration", fileName = "TrailToSpawnConfiguration")]
    public class TrailToSpawnConfiguration : ScriptableObject
    {
        [SerializeField] private TrailId _trailId;
        [SerializeField] private TrailRenderer _trailRenderer;

        [SerializeField] private float _trailUpgradeBaseValue;
        [SerializeField] private int _trailUnlockScoreCost;
        [SerializeField] private int _trailUnlockGemsCost;
        [SerializeField] private int _trailBaseHp;
        [SerializeField] private int _trailBaseAttack;
        [SerializeField] private float _trailCriticalMultiplier;
        [SerializeField] private float _trailCriticalProbability;
        [SerializeField] private float _trailExcelentMultiplier;
        [SerializeField] private float _trailExcelentProbability;
        [SerializeField] private float _trailHpAbsorbProbability;
        [SerializeField] private float _trailHpAbsorbDenominator;
        [SerializeField] private float _trailMultipleHitsProbability;
        [SerializeField] private Sprite _swordImage;
        [SerializeField] private Color _deepBackground;
        [SerializeField] private Color _background;
        [SerializeField] private Color _iconBackground;
        [SerializeField] private Color _nameColor;
        [SerializeField] private Color _levelColor;


        public TrailId TrailId => _trailId;

        public TrailRenderer TrailRenderer => _trailRenderer;
        public float TrailUpgradeBaseValue => _trailUpgradeBaseValue;
        public int TrailUnlockScoreCost => _trailUnlockScoreCost;
        public int TrailUnlockGemsCost => _trailUnlockGemsCost;
        public int TrailBaseHp => _trailBaseHp;
        public int TrailBaseAttack => _trailBaseAttack;
        public float TrailCriticalMultiplier => _trailCriticalMultiplier;
        public float TrailCriticalProbability => _trailCriticalProbability;
        public float TrailExcelentMultiplier => _trailExcelentMultiplier;
        public float TrailExcelentProbability => _trailExcelentProbability;
        public float TrailHpAbsorbProbability => _trailHpAbsorbProbability;
        public float TrailHpAbsorbDenominator => _trailHpAbsorbDenominator;
        public float TrailMultipleHitsProbability => _trailMultipleHitsProbability;
        public Sprite SwordImage => _swordImage;
        public Color DeepBackground => _deepBackground;
        public Color Background => _background;
        public Color IconBackground => _iconBackground;
        public Color NameColor => _nameColor;
        public Color LevelColor => _levelColor;
    }
}