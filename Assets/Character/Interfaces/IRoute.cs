using UnityEngine;

public interface IRoute
{
    void RouteMover();
    Vector3 NextWayPoint();
    void OnDrawGizmos();
}