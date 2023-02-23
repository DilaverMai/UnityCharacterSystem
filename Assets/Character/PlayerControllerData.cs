using UnityEngine;

namespace Character
{
    [CreateAssetMenu(menuName = "Create PlayerControllerData", fileName = "PlayerControllerData", order = 0)]
    public class PlayerControllerData: ScriptableObject
    {
        public float moveSpeed = 10;
        public float rotationSpeed = 10;

        public bool locamationEnabled = true;
    
        public float jumpForce = 10;
        public float gravity = -9.81f;

    }
}