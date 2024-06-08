using UnityEngine;

namespace Assets.Code.Enemies.Projectiles
{
    public class SpawnController : MonoBehaviour
    {

        private int xRange = 2;
        private int xSpawnPos = -7;


        public void Spawn()
        {
            transform.position = new Vector3(Random.Range(-xRange, xRange), xSpawnPos, 0);
        }
    }
}