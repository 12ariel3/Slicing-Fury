using Assets.Code.Common.Events;
using Assets.Code.Core;
using Assets.Code.Enemies.Projectiles.Common;
using UnityEngine;

namespace Assets.Code.Player
{
    public class PlayerHealthController : MonoBehaviour, Damageable
    {
        private PlayerMediator _playerMediator;
        private int _maxHp;
        private int _currentHp;
        private bool _isBlooding;
        private int _bloodyPercentageToActivate = 15;

        public void Configure(PlayerMediator playerMediator, int maxHp)
        {
            _playerMediator = playerMediator;
            _maxHp = maxHp;
            _currentHp = _maxHp;

            var playerMaxHealthChangedEventData = new PlayerMaxHealthChangedEventData(_maxHp, GetInstanceID());
            ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(playerMaxHealthChangedEventData);
        }
        

        public void AddDamage(int amount)
        {
            _currentHp = Mathf.Max(0, _currentHp - amount);

            if (_currentHp <= (_maxHp * _bloodyPercentageToActivate) / 100)
            {
                _isBlooding = true;
            }
            else
            {
                _isBlooding = false;
            }

            var playerHealthChangedEventData = new PlayerHealthChangedEventData(_currentHp, _isBlooding, GetInstanceID());
            ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(playerHealthChangedEventData);

            var isDeath = _currentHp <= 0;
            _playerMediator.OnDamageReceived(isDeath);
        }

        public void AddBadSpecialProjectileDamage()
        {
            int amount;

            if (_maxHp <= 400)
            {
                amount = _maxHp / 3;
            }
            else if (_maxHp > 400 && _maxHp <= 1000)
            {
                amount = _maxHp / 4;
            }
            else
            {
                amount = _maxHp / 5;
            }

            _currentHp = Mathf.Max(0, _currentHp - amount);

            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            var badProjectileDamageAmount = new BadProjectileDamageAmountEventData(amount, GetInstanceID());
            eventQueue.EnqueueEvent(badProjectileDamageAmount);

            if (_currentHp <= (_maxHp * _bloodyPercentageToActivate) / 100)
            {
                _isBlooding = true;
            }
            else
            {
                _isBlooding = false;
            }

            var playerHealthChangedEventData = new PlayerHealthChangedEventData(_currentHp, _isBlooding, GetInstanceID());
            eventQueue.EnqueueEvent(playerHealthChangedEventData);

            var isDeath = _currentHp <= 0;
            _playerMediator.OnDamageReceived(isDeath);
        }


        public void AddHealing(int amount)
        {
            _currentHp = Mathf.Min(_maxHp, _currentHp + amount);

            if (_currentHp <= (_maxHp * _bloodyPercentageToActivate) / 100)
            {
                _isBlooding = true;
            }
            else
            {
                _isBlooding = false;
            }

            var playerHealthChangedEventData = new PlayerHealthChangedEventData(_currentHp, _isBlooding, GetInstanceID());
            ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(playerHealthChangedEventData);
        }

        public void AddGoodSpecialProjectileHealing()
        {
            int amount;
            if (_maxHp <= 300)
            {
                amount = _maxHp / 5;
            }else if(_maxHp > 300 && _maxHp <= 800)
            {
                amount = _maxHp / 6;
            }
            else if (_maxHp > 800 && _maxHp <= 1500)
            {
                amount = _maxHp / 7;
            }
            else
            {
                amount = _maxHp / 8;
            }

            _currentHp = Mathf.Min(_maxHp, _currentHp + amount);

            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            var hpPopUpEventData = new HpPopUpEventData(amount, GetInstanceID());
            eventQueue.EnqueueEvent(hpPopUpEventData);

            if (_currentHp <= (_maxHp * _bloodyPercentageToActivate) / 100)
            {
                _isBlooding = true;
            }
            else
            {
                _isBlooding = false;
            }

            var playerHealthChangedEventData = new PlayerHealthChangedEventData(_currentHp, _isBlooding, GetInstanceID());
            eventQueue.EnqueueEvent(playerHealthChangedEventData);
        }

        public void SetLevelUpNewHealthValues(int newMaxHealth)
        {
            _maxHp = newMaxHealth;
            _currentHp = _maxHp;
            _isBlooding = false;
        }
    }
}