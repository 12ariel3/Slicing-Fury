using Assets.Code.Common.Events;
using Assets.Code.Core;
using Assets.Code.Enemies.Projectiles.Common;
using Assets.Code.Projectiles.Common;
using UnityEngine;

namespace Assets.Code.Enemies.Projectiles
{
    public class HealthController : MonoBehaviour, Damageable
    {
        private Projectile _projectile;
        private int _currentHp;

        private float _criticalMultiplier;
        private float _criticalProbability;
        private float _excelentMultiplier;
        private float _excelentProbability;

        private Vector3 _spawnPopUpPosition;
        private float _hpAbsorbProbability;
        private float _hpAbsorbDenominator;

        public void Configure(Projectile projectile, int level, int maxHp)
        {
            _projectile = projectile;
            _currentHp = Mathf.FloorToInt((maxHp * (level/2)+1));
        }


        public void SetMultipliers(float criticalMultiplier, float criticalProbability, float excelentMultiplier, float excelentProbability)
        {
            _criticalMultiplier = criticalMultiplier;
            _criticalProbability = criticalProbability;
            _excelentMultiplier = excelentMultiplier;
            _excelentProbability = excelentProbability;
        }


        public void AddDamage(int attack)
        {
            if(Random.Range(0, 100f) <= _excelentProbability)
            {
                DoExcellentDamage(attack, _excelentMultiplier);
                return;
            }

            if (Random.Range(0, 100f) <= _criticalProbability)
            {
                DoCriticalDamage(attack, _criticalMultiplier);
                return;
            }

            DoNormalDamage(attack);
            return;
        }


        private void DoExcellentDamage(int attack, float excelentMultiplier)
        {
            int finalAmount = (int)((attack  * Random.Range(0.8f, 1.2f)) * excelentMultiplier);

            var damagePopUpEventData = new DamagePopUpEventData("Excelent", finalAmount, _spawnPopUpPosition, GetInstanceID());
            ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(damagePopUpEventData);

            ApplyDamage(finalAmount);
            ApplyHpAbsorb(excelentMultiplier);
        }


        private void DoCriticalDamage(int attack, float criticalMultiplier)
        {
            int finalAmount = (int)((attack * Random.Range(0.8f, 1.2f))* criticalMultiplier);

            var damagePopUpEventData = new DamagePopUpEventData("Critical", finalAmount, _spawnPopUpPosition, GetInstanceID());
            ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(damagePopUpEventData);

            ApplyDamage(finalAmount);
            ApplyHpAbsorb(criticalMultiplier);
        }

        private void DoNormalDamage(int attack)
        {
            int finalAmount = (int)(attack * Random.Range(0.8f, 1.2f));

            var damagePopUpEventData = new DamagePopUpEventData("Normal", finalAmount, _spawnPopUpPosition, GetInstanceID());
            ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(damagePopUpEventData);

            ApplyDamage(finalAmount);
            ApplyHpAbsorb(1f);
        }


        private void ApplyDamage(int finalAmount)
        {
            _currentHp = Mathf.Max(0, (_currentHp - finalAmount));
            var isDeath = _currentHp <= 0;
            _projectile.OnDamageReceived(isDeath);
        }

        private void ApplyHpAbsorb(float multiplier)
        {
            if (Random.Range(0, 100) <= _hpAbsorbProbability)
            {
                int healingAmount = (int)Mathf.Round(multiplier * _hpAbsorbDenominator);

                var hpPopUpEventData = new HpPopUpEventData(healingAmount, GetInstanceID());
                ServiceLocator.Instance.GetService<EventQueue>().EnqueueEvent(hpPopUpEventData);
            }
        }

        public void SetSpawnPopUpPosition(Vector3 spawnPosition)
        {
            _spawnPopUpPosition = spawnPosition;
        }

        public void SetAbsorbVariables(float HpAbsorbProbability, float HpAbsorbDenominator)
        {
            _hpAbsorbProbability = HpAbsorbProbability;
            _hpAbsorbDenominator = HpAbsorbDenominator;
        }
    }
}