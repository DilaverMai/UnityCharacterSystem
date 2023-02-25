using System;
using System.Collections.Generic;
using System.Linq;
using MaiGames.Scripts.Runtime.Base.InputSystem;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Character
{
    [Serializable]
    public class PlayerJoystickController:IUpdater,IInitializable
    {
        [BoxGroup("References")]
        public CharacterController characterController;
        [BoxGroup("References")]
        public PlayerControllerData playerControllerData;
        
        [BoxGroup("States")]
        public List<CharacterControllerState> characterControllerStates;
        [BoxGroup("States")]
        [ReadOnly]
        public CharacterControllerState currentState;

        public PlayerJoystickController(CharacterController characterController, PlayerControllerData playerControllerData)
        {
            this.characterController = characterController;
            this.playerControllerData = playerControllerData;
        }

        public void ChangeState(CharacterControllerState state)
        {
            foreach (var characterControllerState in characterControllerStates.Where(controllerState => controllerState == state))
            {
                currentState = characterControllerState;
            }
        }
    
        public void OnUpdate()
        {
            if(!currentState) return;
                currentState.Move(Joystick.Instance.GetVector());
        }

        public void Initialize()
        {
            if(characterController == null || playerControllerData == null)
                throw new Exception("PlayerJoystickController is not initialized properly");
            
            foreach (var state in characterControllerStates)
            {
                state.Initialize(ref characterController); 
            }
            
            currentState = characterControllerStates[0];
        }
    }
}