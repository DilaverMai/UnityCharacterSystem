using UnityEngine;

public interface IFinder<out T>
{
    public T FindTarget();
    public Vector3 GetTargetPosition();
    public float TargetDistance { get; }
}