using Assets.Code.Common;
using Assets.Code.ReciclableObjects.PopUps.DamagePopUp;
using System.Collections.Generic;

namespace Assets.Code.ReciclableObjects.DamagePopUp
{
    public class DamagePopUpFactory
    {
        private readonly DamagePopUpConfiguration _configuration;
        private readonly Dictionary<string, ObjectPool> _pools;

        public DamagePopUpFactory(DamagePopUpConfiguration configuration)
        {
            _configuration = configuration;
            var prefabs = _configuration.DamagePrefabs;
            _pools = new Dictionary<string, ObjectPool>(prefabs.Length);

            foreach ( var damagePopUpMediator in prefabs ) 
            {
                var objectPool = new ObjectPool(damagePopUpMediator);
                objectPool.Init(8);
                _pools.Add(damagePopUpMediator.Id, objectPool);
            }
        }

        public DamagePopUpBuilder Create(string id)
        {
            var objectPool = _pools[id];

            return new DamagePopUpBuilder().FromObjectPool(objectPool);
        }
    }
}