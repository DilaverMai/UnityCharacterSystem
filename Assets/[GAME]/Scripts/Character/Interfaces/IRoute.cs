using UnityEngine;

public interface IRoute
{
    Vector3 NextWayPoint();
    Vector3 GetDestination();
    void Reset();
}