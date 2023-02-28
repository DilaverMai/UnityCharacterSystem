using UnityEngine;

namespace _GAME_.Scripts.Player
{
    public interface IRoute
    {
        Vector3 GetTargetPosition();
        Vector3 NextWayPoint();
        bool ReachedDestination();
    }
}