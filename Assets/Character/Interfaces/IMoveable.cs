using UnityEngine;

namespace Character
{
    public interface IMoveable
    {
        void Move(Vector3 position);
        bool ReachedDestination();
        void JumpBack(Vector3 centerPoint);
    }
}