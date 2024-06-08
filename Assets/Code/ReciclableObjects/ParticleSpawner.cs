using Assets.Code.Common.Events;
using Assets.Code.Common.SwordsData;
using Assets.Code.Core;
using Assets.Code.ReciclableObjects.ExplosionParticles;
using Assets.Code.ReciclableObjects.HitParticles;
using UnityEngine;

namespace Assets.Code.ReciclableObjects
{
    public class ParticleSpawner : MonoBehaviour, EventObserver
    {
        private ExplosionParticleSystemFactory _explosionFactory;
        private HitParticleSystemFactory _hitFactory;
        private string _swordEquippedId;


        private void Start()
        {
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Subscribe(EventIds.ProjectileDestroyed, this);
            eventQueue.Subscribe(EventIds.ProjectileHitted, this);
            _explosionFactory = ServiceLocator.Instance.GetService<ExplosionParticleSystemFactory>();
            _hitFactory = ServiceLocator.Instance.GetService<HitParticleSystemFactory>();
            _swordEquippedId = ServiceLocator.Instance.GetService<SwordEquippedSystem>().GetSwordEquipped();
        }
        
        private void OnDestroy()
        {
            var eventQueue = ServiceLocator.Instance.GetService<EventQueue>();
            eventQueue.Unsubscribe(EventIds.ProjectileDestroyed, this);
            eventQueue.Unsubscribe(EventIds.ProjectileHitted, this);
        }


        private void SpawnExplosion(string projectileId, Vector3 position, Quaternion rotation)
        {
            if (position.x > -6.2 && position.x < 5.9 && position.y > -9.9)
            {
                var particleBuilder = _explosionFactory.Create(projectileId);
                particleBuilder.WithPosition(position)
                               .WithRotation(rotation)
                               .Build();
            }
        }

        private void SpawnHit(Vector3 position, Quaternion rotation)
        {
            var particleBuilder = _hitFactory.Create(_swordEquippedId);
            particleBuilder.WithPosition(position)
                           .WithRotation(rotation)
                           .Build();
        }


        public void Process(EventData eventData)
        {
            if (eventData.EventId == EventIds.ProjectileDestroyed)
            {
                var projectileDestroyedEventData = (ProjectileDestroyedEventData)eventData;
                SpawnExplosion(projectileDestroyedEventData.ProjectileId, projectileDestroyedEventData.ProjectilePosition,
                               projectileDestroyedEventData.ProjectileRotation);

                return;
            }

            if (eventData.EventId == EventIds.ProjectileHitted)
            {
                var projectileHittedEventData = (ProjectileHittedEventData)eventData;
                SpawnHit(projectileHittedEventData.Position, projectileHittedEventData.Rotation);
            }
        }

    }
}