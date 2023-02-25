using UnityEngine;

namespace Character
{
    [CreateAssetMenu(menuName = "Create MoveData", fileName = "MoveData", order = 0)]
    public class MoveData: ScriptableObject
    {
        public float Speed;
        public float StoppingDistance;
        public float RotationSpeed;
    }
}