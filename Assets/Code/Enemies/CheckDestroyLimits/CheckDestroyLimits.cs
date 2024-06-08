using UnityEngine;

namespace Assets.Code.Enemies.CheckDestroyLimits
{
    public interface CheckDestroyLimits
    {
        bool IsInsideTheLimits(Vector3 position);
    }
}