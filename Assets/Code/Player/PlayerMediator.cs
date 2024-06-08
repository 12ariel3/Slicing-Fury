using Assets.Code.Common.Events;
using Assets.Code.Common.Settings;
using Assets.Code.Common.SwordsData;
using Assets.Code.Core;
using CandyCoded.HapticFeedback;
using UnityEngine;

namespace Assets.Code.Player
{
    public class PlayerMediator : MonoBehaviour, EventObserver
    {

        [SerializeField] private PlayerStatsController _playerStatsController;
        [SerializeField] private PlayerHealthController _healthController;
        [SerializeField] private PlayerMovementController _movementController;

        [SerializeField] private PlayerId _playerId;
        public string Id => _playerId.Value;


        public bool _pause;
        public bool _isVibrationEnabled;


        private void Start()
        {
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Subscribe(EventIds.GameOver, this);
            eventQueue.Subscribe(EventIds.Victory, this);
            eventQueue.Subscribe(EventIds.PausePressed, this);
            eventQueue.Subscribe(EventIds.LevelUp, this);
            eventQueue.Subscribe(EventIds.ProjectileSpawned, this);
            eventQueue.Subscribe(EventIds.ProjectileDestroyed, this);
            eventQueue.Subscribe(EventIds.HpPopUpValue, this);
            eventQueue.Subscribe(EventIds.SwordEquippedLevelUp, this);
            eventQueue.Subscribe(EventIds.ContinueBattleAfterAds, this);
            eventQueue.Subscribe(EventIds.IsVibrationSettingsChanged, this);
            eventQueue.Subscribe(EventIds.UpgradeNodeActived, this);
            eventQueue.Subscribe(EventIds.BadSpecialProjectileDestroyed, this);
            eventQueue.Subscribe(EventIds.GoodSpecialProjectileDestroyed, this);
            _isVibrationEnabled = ServiceLocator.Instance.GetService<SettingsSystem>().IsVibrationActived();
        }

        private void OnDestroy()
        {
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Unsubscribe(EventIds.GameOver, this);
            eventQueue.Unsubscribe(EventIds.Victory, this);
            eventQueue.Unsubscribe(EventIds.PausePressed, this);
            eventQueue.Unsubscribe(EventIds.LevelUp, this);
            eventQueue.Unsubscribe(EventIds.ProjectileSpawned, this);
            eventQueue.Unsubscribe(EventIds.ProjectileDestroyed, this);
            eventQueue.Unsubscribe(EventIds.HpPopUpValue, this);
            eventQueue.Unsubscribe(EventIds.SwordEquippedLevelUp, this);
            eventQueue.Unsubscribe(EventIds.ContinueBattleAfterAds, this);
            eventQueue.Unsubscribe(EventIds.IsVibrationSettingsChanged, this);
            eventQueue.Unsubscribe(EventIds.UpgradeNodeActived, this);
            eventQueue.Unsubscribe(EventIds.BadSpecialProjectileDestroyed, this);
            eventQueue.Unsubscribe(EventIds.GoodSpecialProjectileDestroyed, this);
        }


        public void Configure(PlayerConfiguration configuration)
        {
            _playerStatsController.ConfigurePlayer(configuration.BaseHp, configuration.Level, configuration.BaseAttack, 
                                             configuration.BaseCriticalMultiplier, configuration.BaseCriticalProbability,
                                             configuration.BaseExcelentMultiplier, configuration.BaseExcelentProbability,
                                             configuration.BaseHpAbsorbDenominator, configuration.BaseHpAbsorbProbability,
                                             configuration.BaseNumberOfHits, configuration.BaseMultipleHitsProbability);
            _playerStatsController.ConfigureTrail(configuration.TrailHp, configuration.TrailAttack, configuration.TrailCriticalMultiplier,
                                             configuration.TrailCriticalProbability, configuration.TrailExcelentMultiplier,
                                             configuration.TrailExcelentProbability, configuration.TrailHpAbsorbDenominator,
                                             configuration.TrailHpAbsorbProbability, configuration.TrailNumberOfHits,
                                             configuration.TrailMultipleHitsProbability);
            _playerStatsController.ConfigureUpgrades(configuration.UpgradesHp, configuration.UpgradesAttack, configuration.UpgradesCriticalMultiplier,
                                             configuration.UpgradesCriticalProbability, configuration.UpgradesExcelentMultiplier,
                                             configuration.UpgradesExcelentProbability, configuration.UpgradesHpAbsorbDenominator,
                                             configuration.UpgradesHpAbsorbProbability, configuration.UpgradesNumberOfHits,
                                             configuration.UpgradesMultipleHitsProbability);
            _playerStatsController.SetFinalValues();
            _healthController.Configure(this, _playerStatsController.FinalHp);
            _movementController.Configure(configuration.TrailRenderer, configuration.TrailId);
            if(configuration.TrailTrailRenderer != null)
            {
                _movementController.Configure(configuration.TrailTrailRenderer, configuration.TrailId);
            }
        }


        private void Update()
        {
            if (!_pause)
            {
                _movementController.TouchFollow2();
            }
        }


        public void OnDamageReceived(bool isDeath)
        {
            if (_isVibrationEnabled)
            {
                HapticFeedback.HeavyFeedback();
            }
                
            if (isDeath)
            {
                var playerDestroyedEventData = new PlayerDestroyedEventData(GetInstanceID());
                ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(playerDestroyedEventData);
            }
        }

        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.LevelUp)
            {
                var levelUpEventData = (LevelUpEventData)eventData;
                _playerStatsController.LevelUp(levelUpEventData.Level);
                _healthController.SetLevelUpNewHealthValues(_playerStatsController.FinalHp);
            }

            if (eventData.EventId == EventIds.ProjectileSpawned)
            {
                var playerSendFinalStatsEventData = new PlayerSendFinalStatsEventData(_playerStatsController.FinalAttack,
                                                _playerStatsController.FinalHp, _playerStatsController.FinalCriticalMultiplier,
                                                _playerStatsController.FinalCriticalProbability, _playerStatsController.FinalExcelentMultiplier,
                                                _playerStatsController.FinalExcelentProbability, _playerStatsController.FinalHpAbsorbProbability,
                                                _playerStatsController.FinalHpAbsorbDenominator, _playerStatsController.FinalMultipleHitsProbability,
                                                _playerStatsController.FinalNumberOfHits, GetInstanceID());
                ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(playerSendFinalStatsEventData);
            }

            if (eventData.EventId == EventIds.ProjectileDestroyed)
            {
                var projectileDestroyedEventData = (ProjectileDestroyedEventData)eventData;

                _healthController.AddDamage(projectileDestroyedEventData.AttackToRest);
            }

            if (eventData.EventId == EventIds.BadSpecialProjectileDestroyed)
            {
                _healthController.AddBadSpecialProjectileDamage();
            }

            if (eventData.EventId == EventIds.GoodSpecialProjectileDestroyed)
            {
                _healthController.AddGoodSpecialProjectileHealing();
            }

            if (eventData.EventId == EventIds.HpPopUpValue)
            { 
                var hpPopUpEventData = (HpPopUpEventData)eventData;
                _healthController.AddHealing(hpPopUpEventData.HpValue);
            }
            if (eventData.EventId == EventIds.SwordEquippedLevelUp)
            {
                var swordEquippedLevelUpEventData = (SwordEquippedLevelUpEventData)eventData;
                if (ServiceLocator.Instance.GetService<SwordEquippedSystem>().GetSwordEquipped() == swordEquippedLevelUpEventData.Id)
                {
                    _playerStatsController.ConfigureTrail(swordEquippedLevelUpEventData.Hp, swordEquippedLevelUpEventData.Attack,
                                             swordEquippedLevelUpEventData.CriticalMultiplier, swordEquippedLevelUpEventData.CriticalProbability,
                                             swordEquippedLevelUpEventData.ExcelentMultiplier, swordEquippedLevelUpEventData.ExcelentProbability,
                                             swordEquippedLevelUpEventData.HpAbsorbDenominator, swordEquippedLevelUpEventData.HpAbsorbProbability,
                                             swordEquippedLevelUpEventData.NumberOfHits, swordEquippedLevelUpEventData.MultipleHitsProbability);

                    _playerStatsController.SetFinalValues();
                }
            }

            if (eventData.EventId == EventIds.PausePressed)
            {
                if(_pause == true)
                {
                    _pause = false;
                }
                else
                {
                    _pause = true;
                }
            }
            
            if (eventData.EventId == EventIds.ContinueBattleAfterAds)
            {
                _healthController.Configure(this, _playerStatsController.FinalHp);
            }

            if (eventData.EventId == EventIds.IsVibrationSettingsChanged)
            {
                _isVibrationEnabled = ServiceLocator.Instance.GetService<SettingsSystem>().IsVibrationActived();
            }
            
            if (eventData.EventId == EventIds.UpgradeNodeActived)
            {
                _playerStatsController.SetFinalValues();
            }
        }
    }
}