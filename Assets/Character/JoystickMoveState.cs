using System;
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
            //rotate character
            _characterController.transform.rotation = 
                Quaternion.Lerp(_characterController.transform.rotation, Quaternion.Euler(0, angle, 0), _playerControllerData.rotationSpeed * Time.fixedDeltaTime);
        }

        public override void Jump(Vector3 centerPoint)
        {
            throw new NotImplementedException();
        }

        public override void JumpBack(Vector3 centerPoint)
        {
            throw new NotImplementedException();
        }

        public override bool ReachedDestination()
        {
            throw new NotImplementedException();
        }

        public override Vector3 CalculateMovement(ref Vector3 input)
        {
            return new Vector3(input.x, _playerControllerData.gravity, input.y) * (_playerControllerData.moveSpeed * Time.fixedDeltaTime);
        }
    }
}