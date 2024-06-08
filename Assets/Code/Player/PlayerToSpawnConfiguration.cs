using UnityEngine;

namespace Assets.Code.Player
{
    [CreateAssetMenu(menuName = "Player/PlayerToSpawnConfiguration", fileName = "PlayerToSpawnConfiguration")]
    public class PlayerToSpawnConfiguration : ScriptableObject
    {
        [SerializeField] private PlayerId _playerId;
        [SerializeField] private TrailRenderer _trailRenderer;

        [SerializeField] private int _baseHp;
        [SerializeField] private int _baseAttack;
        [SerializeField] private float _baseCriticalMultiplier;
        [SerializeField] private float _baseCriticalProbability;
        [SerializeField] private float _baseExcelentMultiplier;
        [SerializeField] private float _baseExcelentProbability;
        [SerializeField] private float _baseHpAbsorbProbability;
        [SerializeField] private float _baseHpAbsorbDenominator;
        [SerializeField] private float _baseMultipleHitsProbability;
        [SerializeField] private int _baseNumberOfHits;


        public PlayerId PlayerId => _playerId;

        public TrailRenderer TrailRenderer => _trailRenderer;
        public int BaseHp => _baseHp;
        public int BaseAttack => _baseAttack;
        public float BaseCriticalMultiplier => _baseCriticalMultiplier;
        public float BaseCriticalProbability => _baseCriticalProbability;
        public float BaseExcelentMultiplier => _baseExcelentMultiplier;
        public float BaseExcelentProbability => _baseExcelentProbability;
        public float BaseHpAbsorbProbability => _baseHpAbsorbProbability;
        public float BaseHpAbsorbDenominator => _baseHpAbsorbDenominator;
        public float BaseMultipleHitsProbability => _baseMultipleHitsProbability;
        public int BaseNumberOfHits => _baseNumberOfHits;
    }
}