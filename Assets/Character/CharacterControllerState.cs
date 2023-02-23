using System;
using UnityEditor.VersionControl;
using UnityEngine;
using Task = System.Threading.Tasks.Task;

namespace Character
{
    [Serializable]
    public abstract class CharacterControllerState: ScriptableObject
    {
        public string stateName;
        protected PlayerControllerData _playerControllerData;
        protected CharacterController _characterController;

        private Vector3 targetPosition;
        
        public virtual void Move(Vector3 position)
        {
            if(position != Vector3.zero)
            {
                Rotation(ref targetPosition);
                targetPosition = CalculateMovement(ref position);
            }
            else LocamationMovement(targetPosition);
            
            _characterController.Move(targetPosition);
        }
    
        public virtual void Rotation(ref Vector3 position)
        {
            _characterController.transform.rotation = Quaternion.LookRotation(position);
        }
    
        public abstract void Jump(Vector3 centerPoint);
        public virtual void JumpBack(Vector3 centerPoint)
        {
            
        }
        public virtual bool ReachedDestination()
        {
            return Vector3.Distance(_characterController.transform.position, targetPosition) <= 0.1f;
        }

        public virtual async void LocamationMovement(Vector3 movement)
        {
            if(targetPosition.magnitude <= 0) return;
            
            while (targetPosition.magnitude > 0)
            {
               targetPosition = Vector3.MoveTowards(targetPosition, Vector3.zero,_playerControllerData.LocamationSpeed * Time.fixedDeltaTime);
               await Task.Delay(50);
               if(!Application.isPlaying) break;
            }
        }

        public virtual Vector3 CalculateMovement(ref Vector3 input)
        {
            if (!_playerControllerData.ForwardMovement)
                return input * (_playerControllerData.moveSpeed * Time.fixedDeltaTime);

            var transform = _characterController.transform;
            return transform.forward * input.z + transform.right * input.x;
        }

        public void Initialize(ref PlayerControllerData playerControllerData, ref CharacterController characterController)
        {
            this._playerControllerData = playerControllerData;
            this._characterController = characterController;
        }

        public void OnGizmos()
        {
            //calculate destination positon by character controller velocity
            if(_playerControllerData == null || _characterController == null) 
                return;
            var pos = _characterController.velocity * Time.fixedDeltaTime * _playerControllerData.moveSpeed;
            var position = _characterController.transform.position;
            var destinationPosition = position + pos;

            
            Gizmos.color = Color.green;
            Gizmos.DrawSphere(destinationPosition, 0.25f);
            
            Gizmos.DrawLine(position,destinationPosition);
        }
    }
}