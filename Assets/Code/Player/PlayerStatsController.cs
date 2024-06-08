using Assets.Code.Common.Events;
using Assets.Code.Common.UpgradesData;
using Assets.Code.Core;
using UnityEngine;

namespace Assets.Code.Player
{
    public class PlayerStatsController : MonoBehaviour
    {
        // base stats given by the playerToSpawnConfiguration
        private int _level;

        private int _baseAttack;
        private int _baseHp;
        private float _baseCriticalMultiplier;
        private float _baseCriticalProbability;
        private float _baseExcelentMultiplier;
        private float _baseExcelentProbability;
        private float _baseHpAbsorbDenominator;
        private float _baseHpAbsorbProbability;
        private float _baseMultipleHitsProbability;
        private int _baseNumberOfHits;


        // player stats

        private int _playerAttack;
        private int _playerHp;
        private float _playerCriticalMultiplier;
        private float _playerCriticalProbability;
        private float _playerExcelentMultiplier;
        private float _playerExcelentProbability;
        private float _playerHpAbsorbDenominator;
        private float _playerHpAbsorbProbability;
        private float _playerMultipleHitsProbability;
        private int _playerNumberOfHits;


        // trail stats

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

        // final stats

        private int _finalAttack;
        private int _finalHp;
        private float _finalCriticalMultiplier;
        private float _finalCriticalProbability;
        private float _finalExcelentMultiplier;
        private float _finalExcelentProbability;
        private float _finalHpAbsorbDenominator;
        private float _finalHpAbsorbProbability;
        private float _finalMultipleHitsProbability;
        private int _finalNumberOfHits;




        public int Level => _level;
        public int FinalAttack => _finalAttack;
        public int FinalHp => _finalHp;
        public float FinalCriticalMultiplier => _finalCriticalMultiplier;
        public float FinalCriticalProbability => _finalCriticalProbability;
        public float FinalExcelentMultiplier => _finalExcelentMultiplier;
        public float FinalExcelentProbability => _finalExcelentProbability;
        public float FinalHpAbsorbDenominator => _finalHpAbsorbDenominator;
        public float FinalHpAbsorbProbability => _finalHpAbsorbProbability;
        public float FinalMultipleHitsProbability => _finalMultipleHitsProbability;
        public int FinalNumberOfHits => _finalNumberOfHits;


        public void ConfigurePlayer(int baseHp, int level, int baseAttack, float baseCriticalMultiplier, float baseCriticalProbability,
                              float baseExcelentMultiplier, float baseExcelentProbability, float baseHpAbsorbDenominator,
                              float baseHpAbsorbProbability, int baseNumberOfHits, float baseMultipleHitsProbability)
        {
            _level = level;
            _baseAttack = baseAttack;
            _baseHp = baseHp;
            _baseCriticalMultiplier = baseCriticalMultiplier;
            _baseCriticalProbability = baseCriticalProbability;
            _baseExcelentMultiplier = baseExcelentMultiplier;
            _baseExcelentProbability = baseExcelentProbability;
            _baseHpAbsorbDenominator = baseHpAbsorbDenominator;
            _baseHpAbsorbProbability = baseHpAbsorbProbability;
            _baseMultipleHitsProbability = baseMultipleHitsProbability;
            _baseNumberOfHits = baseNumberOfHits;

            SetPlayerValues();
        }



        public void ConfigureTrail(int trailHp, int trailAttack, float trailCriticalMultiplier, float trailCriticalProbability,
                              float trailExcelentMultiplier, float trailExcelentProbability, float trailHpAbsorbDenominator,
                              float trailHpAbsorbProbability, int trailNumberOfHits, float trailMultipleHitsProbability)
        {
             _trailAttack = trailAttack;
             _trailHp = trailHp;
             _trailCriticalMultiplier = trailCriticalMultiplier;
             _trailCriticalProbability = trailCriticalProbability;
             _trailExcelentMultiplier = trailExcelentMultiplier;
             _trailExcelentProbability = trailExcelentProbability;
             _trailHpAbsorbDenominator = trailHpAbsorbDenominator;
             _trailHpAbsorbProbability = trailHpAbsorbProbability;
             _trailMultipleHitsProbability = trailMultipleHitsProbability;
             _trailNumberOfHits = trailNumberOfHits;
        }


        public void ConfigureUpgrades(float upgradesHp, float upgradesAttack, float upgradesCriticalMultiplier, float upgradesCriticalProbability,
                              float upgradesExcelentMultiplier, float upgradesExcelentProbability, float upgradesHpAbsorbDenominator,
                              float upgradesHpAbsorbProbability, float upgradesNumberOfHits, float upgradesMultipleHitsProbability)
        {
            _upgradesAttack = upgradesAttack;
            _upgradesHp = upgradesHp;
            _upgradesCriticalMultiplier = upgradesCriticalMultiplier;
            _upgradesCriticalProbability = upgradesCriticalProbability;
            _upgradesExcelentMultiplier = upgradesExcelentMultiplier;
            _upgradesExcelentProbability = upgradesExcelentProbability;
            _upgradesHpAbsorbDenominator = upgradesHpAbsorbDenominator;
            _upgradesHpAbsorbProbability = upgradesHpAbsorbProbability;
            _upgradesMultipleHitsProbability = upgradesMultipleHitsProbability;
            _upgradesNumberOfHits = upgradesNumberOfHits;
        }

        public void SetUpgradeValues()
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
        }


        public void LevelUp(int level)
        {
            _level = level;
            SetFinalValues();
        }



        private void SetPlayerValues()
        {
            _playerAttack = Mathf.FloorToInt(((_baseAttack * _level * _level) / 100f) + 5);
            _playerHp = Mathf.FloorToInt(((_baseHp * (_level/2f) * (_level/2f)) / 10f) + 100f);
            _playerCriticalMultiplier = _baseCriticalMultiplier + (_level / 200f);
            _playerCriticalProbability = _baseCriticalProbability + (_level / 10f);
            _playerExcelentMultiplier = _baseExcelentMultiplier + (_level / 100f);
            _playerExcelentProbability = _baseExcelentProbability + (_level / 20f);
            _playerHpAbsorbDenominator = (_playerAttack / (_baseHpAbsorbDenominator - (_level / 50f)));           
            _playerHpAbsorbProbability = _baseHpAbsorbProbability + (_level / 10f);            
            _playerMultipleHitsProbability = _baseMultipleHitsProbability + (_level / 20f);    
            _playerNumberOfHits = _baseNumberOfHits;
        }


        public void SetFinalValues()
        {
            SetPlayerValues();
            SetUpgradeValues();

            _finalAttack = (int)(_playerAttack + _trailAttack + _upgradesAttack);
            _finalHp = (int)(_playerHp + _trailHp + _upgradesHp);
            _finalCriticalMultiplier = _playerCriticalMultiplier + _trailCriticalMultiplier + _upgradesCriticalMultiplier;
            _finalCriticalProbability = _playerCriticalProbability + _trailCriticalProbability + _upgradesCriticalProbability;
            _finalExcelentMultiplier = _playerExcelentMultiplier + _trailExcelentMultiplier + _upgradesExcelentMultiplier;
            _finalExcelentProbability = _playerExcelentProbability + _trailExcelentProbability + _upgradesExcelentProbability;
            _finalHpAbsorbDenominator = _playerHpAbsorbDenominator + _trailHpAbsorbDenominator + _upgradesHpAbsorbDenominator;
            _finalHpAbsorbProbability = _playerHpAbsorbProbability + _trailHpAbsorbProbability + _upgradesHpAbsorbProbability;
            _finalMultipleHitsProbability = _playerMultipleHitsProbability + _trailMultipleHitsProbability + _upgradesMultipleHitsProbability;
            _finalNumberOfHits = (int)(_playerNumberOfHits + _trailNumberOfHits + _upgradesNumberOfHits);

            var playerSendEveryStatsEventData = new playerSendEveryStatsEventData(_playerAttack, _playerHp, _playerCriticalMultiplier,
                                    _playerCriticalProbability, _playerExcelentMultiplier, _playerExcelentProbability,
                                    _playerHpAbsorbProbability, _playerHpAbsorbDenominator, _playerMultipleHitsProbability,
                                    _playerNumberOfHits,

                                    _trailAttack, _trailHp, _trailCriticalMultiplier, _trailCriticalProbability, _trailExcelentMultiplier,
                                    _trailExcelentProbability, _trailHpAbsorbProbability, _trailHpAbsorbDenominator,
                                    _trailMultipleHitsProbability, _trailNumberOfHits,

                                    _upgradesAttack, _upgradesHp, _upgradesCriticalMultiplier, _upgradesCriticalProbability,
                                    _upgradesExcelentMultiplier, _upgradesExcelentProbability, _upgradesHpAbsorbProbability,
                                    _upgradesHpAbsorbDenominator, _upgradesMultipleHitsProbability, _upgradesNumberOfHits, 
                                    GetInstanceID());

            ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(playerSendEveryStatsEventData);


            var playerSendFinalStatsEventData = new PlayerSendFinalStatsEventData(_finalAttack, _finalHp, _finalCriticalMultiplier,
                                                _finalCriticalProbability, _finalExcelentMultiplier, _finalExcelentProbability,
                                                _finalHpAbsorbProbability, _finalHpAbsorbDenominator, _finalMultipleHitsProbability,
                                                _finalNumberOfHits, GetInstanceID());

            ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(playerSendFinalStatsEventData);

            var playerMaxHealthChangedEventData = new PlayerMaxHealthChangedEventData(_finalHp, GetInstanceID());
            ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(playerMaxHealthChangedEventData);
        }
    }
}