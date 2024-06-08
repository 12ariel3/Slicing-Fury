using Assets.Code.Common.Level;
using Assets.Code.Common.UpgradesData;
using Assets.Code.Core;
using UnityEngine;

namespace Assets.Code.Player
{
    public class PlayerBuilder
    {
        private PlayerToSpawnConfiguration _playerConfiguration;
        private PlayerMediator _prefab;
        private int _level;
        private Vector3 _position = Vector3.zero;
        private Quaternion _rotation = Quaternion.identity;
        private PlayerMediator _prefabInstantiated;

        // trail stats

        private string _trailId;
        private int _trailAttack;
        private int _trailHp;
        private float _trailCriticalMultiplier;
        private float _trailCriticalProbability;
        private float _trailExcelentMultiplier;
        private float _trailExcelentProbability;
        private float _trailHpAbsorbDenominator;
        private float _trailHpAbsorbProbability;
        private float _trailMultipleHitsProbability;
        private int _trailNumberOfHits;
        private TrailRenderer _trailTrailRenderer;


        // upgrades stats

        private float _upgradesAttack;
        private float _upgradesHp;
        private float _upgradesCriticalMultiplier;
        private float _upgradesCriticalProbability;
        private float _upgradesExcelentMultiplier;
        private float _upgradesExcelentProbability;
        private float _upgradesHpAbsorbDenominator;
        private float _upgradesHpAbsorbProbability;
        private float _upgradesMultipleHitsProbability;
        private float _upgradesNumberOfHits;

        public PlayerBuilder WithTrailStats(string trailId, int trailHp, int trailAttack,
                                   float trailCriticalMultiplier, float trailCriticalProbability, float trailExcelentMultiplier,
                                   float trailExcelentProbability, float trailHpAbsorbProbability, float trailHpAbsorbDenominator,
                                   float trailMultipleHitsProbability, int trailNumberOfHits, TrailRenderer trailRenderer)
        {
            _trailId = trailId;
            _trailHp = trailHp;
            _trailAttack = trailAttack;
            _trailCriticalMultiplier = trailCriticalMultiplier;
            _trailCriticalProbability = trailCriticalProbability;
            _trailExcelentMultiplier = trailExcelentMultiplier;
            _trailExcelentProbability = trailExcelentProbability;
            _trailHpAbsorbProbability = trailHpAbsorbProbability;
            _trailHpAbsorbDenominator = trailHpAbsorbDenominator;
            _trailMultipleHitsProbability = trailMultipleHitsProbability;
            _trailNumberOfHits = trailNumberOfHits;
            _trailTrailRenderer = trailRenderer;
            return this;
        }

        public PlayerBuilder WithUpgradesStats()
        {
            var upgradeSystem = ServiceLocator.Instance.GetService<UpgradesSystem>();
            _upgradesAttack = upgradeSystem.GetUpgradeAttack();
            _upgradesHp = upgradeSystem.GetUpgradeHp();
            _upgradesCriticalMultiplier = upgradeSystem.GetUpgradeCriticalMultiplier();
            _upgradesCriticalProbability = upgradeSystem.GetUpgradeCriticalProbability();
            _upgradesExcelentMultiplier = upgradeSystem.GetUpgradeExcelentMultiplier();
            _upgradesExcelentProbability = upgradeSystem.GetUpgradeExcelentProbability();
            _upgradesHpAbsorbDenominator = upgradeSystem.GetUpgradeHpAbsorbDenominator();
            _upgradesHpAbsorbProbability = upgradeSystem.GetUpgradeHpAbsorbProbability();
            _upgradesMultipleHitsProbability = upgradeSystem.GetUpgradeMultipleHitsProbability();
            _upgradesNumberOfHits = upgradeSystem.GetUpgradeNumberOfHits();
            return this;
        }

        public PlayerBuilder WithConfiguration(PlayerToSpawnConfiguration playerConfiguration)
        {
            _playerConfiguration = playerConfiguration;
            return this;
        }


        public PlayerBuilder FromPrefab(PlayerMediator prefab)
        {
            _prefab = prefab;
            return this;
        }

        public PlayerBuilder WithLevel()
        {
            _level = ServiceLocator.Instance.GetService<LevelSystem>().GetCurrentLevel();
            return this;
        }

        public PlayerMediator Build()
        {
            var playerConfiguration = new PlayerConfiguration(_level,
                                                              _playerConfiguration.BaseHp,
                                                              _playerConfiguration.BaseAttack,
                                                              _playerConfiguration.BaseCriticalMultiplier,
                                                              _playerConfiguration.BaseCriticalProbability,
                                                              _playerConfiguration.BaseExcelentMultiplier,
                                                              _playerConfiguration.BaseExcelentProbability,
                                                              _playerConfiguration.BaseHpAbsorbProbability,
                                                              _playerConfiguration.BaseHpAbsorbDenominator,
                                                              _playerConfiguration.BaseMultipleHitsProbability,
                                                              _playerConfiguration.BaseNumberOfHits,
                                                              _playerConfiguration.PlayerId,
                                                              _playerConfiguration.TrailRenderer,

                                                              _trailId, _trailHp, _trailAttack, _trailCriticalMultiplier,
                                                              _trailCriticalProbability, _trailExcelentMultiplier,
                                                              _trailExcelentProbability, _trailHpAbsorbProbability, 
                                                              _trailHpAbsorbDenominator, _trailMultipleHitsProbability,
                                                              _trailNumberOfHits, _trailTrailRenderer,
                                                              
                                                              _upgradesHp, _upgradesAttack, _upgradesCriticalMultiplier,
                                                              _upgradesCriticalProbability, _upgradesExcelentMultiplier,
                                                              _upgradesExcelentProbability, _upgradesHpAbsorbProbability,
                                                              _upgradesHpAbsorbDenominator, _upgradesMultipleHitsProbability,
                                                              _upgradesNumberOfHits);
            if(_prefabInstantiated == null) 
            {
                var player = Object.Instantiate(_prefab, _position, _rotation);
                _prefabInstantiated = player;
                _prefabInstantiated.Configure(playerConfiguration);
                return _prefabInstantiated;
            }
            else
            {
                _prefabInstantiated.Configure(playerConfiguration);
                return _prefabInstantiated;
            }
        }
    }
}