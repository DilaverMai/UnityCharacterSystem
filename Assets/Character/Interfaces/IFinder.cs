using UnityEngine;

public interface IFinder<out T>
{
    public T FindTarget();
    public Vector3 GetTargetPosition();
    public void AfterFind();
    public void Reset();
    public float TargetDistance { get; }
}