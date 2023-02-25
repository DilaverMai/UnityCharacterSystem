using UnityEngine;
namespace _GAME_.Scripts.Character.Interfaces
{
    public interface IMovable
    {
        void Move(Vector3 position);
        bool ReachedDestination();
        void JumpBack(Vector3 centerPoint);
        void Stop();
    }
}