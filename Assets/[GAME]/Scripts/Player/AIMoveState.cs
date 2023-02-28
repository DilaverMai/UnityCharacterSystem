using System;
using _GAME_.Scripts.Character;
using UnityEngine;

namespace _GAME_.Scripts.Player
{
    [Serializable]
    public abstract class AIMoveState
    {
        private Vector3 spawnPoint;
        
        public float speed;
        public float stoppingDistance;
        public float rotationSpeed;

        protected AIMoveState(AIMoveData aiMoveData)
        {
            speed = aiMoveData.speed;
            stoppingDistance = aiMoveData.stoppingDistance;
            rotationSpeed = aiMoveData.rotationSpeed;
        }

        public abstract Vector3 GetTargetPosition();
    }
}