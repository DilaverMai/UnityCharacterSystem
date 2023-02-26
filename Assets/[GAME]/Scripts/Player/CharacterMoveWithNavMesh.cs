using System.Collections.Generic;
using _GAME_.Scripts.Character;
using _GAME_.Scripts.Character.Interfaces;
using Character;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace _GAME_.Scripts.Player
{
    [RequireComponent((typeof(NavMeshAgent)))]
    [System.Serializable]
    public abstract class CharacterMoveWithNavMesh:MonoBehaviour,IUpdater, IInitializable, IMovable
    {
        [BoxGroup("Data")]
        public NavMeshAgent NavAgent;
        [BoxGroup("Event")]
        public UnityEvent onReachedDestination;

        public List<AIMoveData> aiMoveState;
        [ShowInInspector,ReadOnly]
        private AIMoveData _currentAIMoveState;

        private void Awake()
        {
            NavAgent = GetComponent<NavMeshAgent>();
        }

        public void Initialize()
        {
            NavAgent.speed = _currentAIMoveState.speed;
            NavAgent.stoppingDistance = _currentAIMoveState.stoppingDistance;
            NavAgent.angularSpeed = _currentAIMoveState.rotationSpeed;
        }

        public virtual void Move(Vector3 position)
        {
            NavAgent.SetDestination(position);
        }
        
        public bool ReachedDestination()
        {
            onReachedDestination?.Invoke();
            return NavAgent.remainingDistance <= NavAgent.stoppingDistance;
        }
        
        public void JumpBack(Vector3 centerPoint)
        {
            NavAgent.enabled = false;
            transform.position = centerPoint + (transform.position - centerPoint).normalized * 10;
            NavAgent.enabled = true;
        }
        public void Stop()
        {
            NavAgent.isStopped = true;
        }

        public void OnUpdate()
        {
            
        }
    }
}