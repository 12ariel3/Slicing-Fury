using Assets.Code.Common;
using System.Collections.Generic;

namespace Assets.Code.ReciclableObjects.ExplosionParticles
{
    public class ExplosionParticleSystemFactory
    {
        private readonly ExplosionParticlesSystemConfiguration _configuration;
        private readonly Dictionary<string, ObjectPool> _pools;


        public ExplosionParticleSystemFactory(ExplosionParticlesSystemConfiguration configuration, string currentMapName)
        {
            _configuration = configuration;
            var prefabs = _configuration.GetArrayById(currentMapName);
            _pools = new Dictionary<string, ObjectPool>(prefabs.Length);

            foreach (var particleMediator in prefabs)
            {
                var objectPool = new ObjectPool(particleMediator);
                objectPool.Init(2);
                _pools.Add(particleMediator.Id, objectPool);
            }
        }

        public ParticleBuilder Create(string id)
        {
            var objectPool = _pools[id];

            return new ParticleBuilder().FromObjectPool(objectPool);
        }
    }
}
