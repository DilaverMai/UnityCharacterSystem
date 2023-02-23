using System;
using System.Collections;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Character
{
    public class Player : CharacterBase
    {
        [ShowInInspector]
        public PlayerJoystickController playerJoystickController;
        public override void OnDeath()
        {
            
        }

        public override void OnSpawn()
        {
            playerJoystickController.Initialize();
            StartCoroutine(OnUpdater());
        }

        private IEnumerator OnUpdater()
        {
            while (CharacterStates.Die != CharacterState)
            {
                playerJoystickController.OnUpdate();
                yield return new WaitForFixedUpdate();
            }
        }


        private void OnDrawGizmos()
        {
            playerJoystickController.currentState?.OnGizmos();
        }
    }


}