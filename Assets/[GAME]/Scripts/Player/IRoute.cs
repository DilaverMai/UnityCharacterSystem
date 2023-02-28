using UnityEngine;

namespace _GAME_.Scripts.Player
{
    public interface IRoute
    {
        Vector3 NextWayPoint();
        Vector3 GetCurrentRoutePoint();
    }
}