using System;
using UnityEditor.VersionControl;
using UnityEngine;

namespace Character
{
    [Serializable]
    public abstract class CharacterControllerState: ScriptableObject
    {
        public string stateName;
        protected PlayerControllerData _playerControllerData;
        protected CharacterController _characterController;

        private float _locamationTime = 1f;
        
        public virtual void Move(Vector3 position)
        {
            var movement = CalculateMovement(ref position);
        
            if(position != Vector3.zero)
                Rotation(ref movement);
            
            _characterController.Move(movement);
        }
    
        public virtual void Rotation(ref Vector3 position)
        {
            _characterController.transform.rotation = Quaternion.LookRotation(position);
        }
    
        public abstract void Jump(Vector3 centerPoint);
        public abstract void JumpBack(Vector3 centerPoint);
        public abstract bool ReachedDestination();

        public void Locamation(ref Vector3 movement)
        {
            while (_locamationTime > 0)
            {
                //await UniTask.DelayFrame(1);
                _characterController.Move(movement * (_locamationTime * Time.fixedDeltaTime));
            }
        }

        public virtual Vector3 CalculateMovement(ref Vector3 input)
        {
            return input * (_playerControllerData.moveSpeed * Time.fixedDeltaTime);
        }

        public void Initialize(ref PlayerControllerData playerControllerData, ref CharacterController characterController)
        {
            this._playerControllerData = playerControllerData;
            this._characterController = characterController;
        }
    }
}