using UnityEngine;
namespace _GAME_.Scripts.Character.Interfaces
{
    public interface IMovable
    {
        void Move();
        bool ReachedDestination();
        void JumpBack(Vector3 centerPoint);
        void Stop();
    }
}