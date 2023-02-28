using System;
using System.Collections.Generic;
using _GAME_.Scripts.Character;
using _GAME_.Scripts.Character.Interfaces;
using _GAME_.Scripts.UpgradeSystem;
using Character;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

namespace _GAME_.Scripts.Player
{
    [RequireComponent((typeof(NavMeshAgent)))]
    [System.Serializable]
    public class CharacterMoveWithNavMesh:MonoBehaviour, IInitializable, IMovable
    {
        [BoxGroup("Data")]
        public NavMeshAgent NavAgent;
        [BoxGroup("Event")]
        public UnityEvent onReachedDestination;

        public List<AIMoveData> aiMoveStates;
        [ShowInInspector,ReadOnly]
        
        private AIMoveState _currentAIMoveState;
        private List<AIMoveState> _aiMoveStates = new List<AIMoveState>();

        private void Awake()
        {
            NavAgent = GetComponent<NavMeshAgent>();

            foreach (var state in aiMoveStates)
            {
                switch (state.moveState)
                {
                    case CharacterAIMoveState.Idle:
                        break;
                    case CharacterAIMoveState.Patrol:
                        var patrolState = new AIRoute(state,transform);
                        _aiMoveStates.Add(patrolState);
                        break;
                    case CharacterAIMoveState.Chase:
                        break;
                    case CharacterAIMoveState.Attack:
                        break;
                    case CharacterAIMoveState.Flee:
                        break;
                    case CharacterAIMoveState.Dead:
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            
            _currentAIMoveState = _aiMoveStates[0];
        }

        public void Initialize()
        {
            NavAgent.speed = _currentAIMoveState.speed;
            NavAgent.stoppingDistance = _currentAIMoveState.stoppingDistance;
            NavAgent.angularSpeed = _currentAIMoveState.rotationSpeed;
        }

        public virtual void Move()
        {
            NavAgent.SetDestination(_currentAIMoveState.GetTargetPosition());
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

        private void Update()
        {
            if (_currentAIMoveState == null) return;
            Move();
        }
    }
}