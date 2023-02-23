using UnityEngine;

namespace Character
{
    [CreateAssetMenu(menuName = "Create NormalMoveState", fileName = "NormalMoveState", order = 0)]
    public class JoystickMoveState : CharacterControllerState
    {
        public override void Rotation(ref Vector3 position)
        {
            //calculate angle by joystick input
            var angle = Mathf.Atan2(position.x, position.z) * Mathf.Rad2Deg;
            if(angle == 0) return;
            
            //rotate character
            _characterController.transform.rotation = 
                Quaternion.RotateTowards(_characterController.transform.rotation, 
                    Quaternion.Euler(0, angle, 0), 
                    _playerControllerData.rotationSpeed);
        }

        public override void Jump(Vector3 centerPoint)
        {
            //calculate jump direction
            var jumpDirection = (centerPoint - _characterController.transform.position).normalized;
            //add jump force
            _characterController.Move(jumpDirection * _playerControllerData.jumpForce * Time.fixedDeltaTime);
        }
        
        public override Vector3 CalculateMovement(ref Vector3 input)
        {
            return new Vector3(input.x, _playerControllerData.gravity, input.y) * (_playerControllerData.moveSpeed * Time.fixedDeltaTime);
        }
    }
}