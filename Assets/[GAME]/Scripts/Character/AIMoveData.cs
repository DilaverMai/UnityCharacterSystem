using UnityEngine;

namespace Character
{
    [CreateAssetMenu(menuName = "AI/Create MoveData", fileName = "MoveData", order = 0)]
    public class AIMoveData: ScriptableObject
    {
        public float Speed;
        public float StoppingDistance;
        public float RotationSpeed;
    }
}