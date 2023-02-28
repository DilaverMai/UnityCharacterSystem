using System;
using _GAME_.Scripts.Character;
using _GAME_.Scripts.Character.Interfaces;
using UnityEngine;
using UnityEngine.AI;

namespace _GAME_.Scripts.Player
{
    [Serializable]
    public abstract class AIMoveStateWithNav: IMovable
    {
        protected readonly NavMeshAgent navMeshAgent;
        private Vector3 spawnPoint;
        
        public float speed;
        public float stoppingDistance;
        public float rotationSpeed;

        protected AIMoveStateWithNav(AIMoveData aiMoveData)
        {
            speed = aiMoveData.speed;
            stoppingDistance = aiMoveData.stoppingDistance;
            rotationSpeed = aiMoveData.rotationSpeed;
        }

        public abstract void Move(Vector3 targetPosition = default);
        
        public bool ReachedDestination()
        {
            return navMeshAgent.remainingDistance <= navMeshAgent.stoppingDistance;
        }

        public void JumpBack(Vector3 centerPoint)
        {
            
        }

        public virtual void Stop()
        {
            navMeshAgent.isStopped = true;
        }
    }
}