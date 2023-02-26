using System.Collections;
using System.Collections.Generic;
using _GAME_.Scripts.Character.Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace Character
{
    [RequireComponent((typeof(NavMeshAgent)))]
    [System.Serializable]
    public class CharacterMoveWithNavMesh:MonoBehaviour, IInitializable, IMovable
    {

        [BoxGroup("Data")]
        public NavMeshAgent NavAgent;
        [BoxGroup("Event")]
        public UnityEvent OnReachedDestination;

        public List<AIMoveState> AIMoveState;
        public AIMoveState CurrentAIMoveState;

        private void Awake()
        {
            NavAgent = GetComponent<NavMeshAgent>();
        }

        public void Initialize()
        {
            NavAgent.speed = CurrentAIMoveState.aiMoveData.Speed;
            NavAgent.stoppingDistance = CurrentAIMoveState.aiMoveData.StoppingDistance;
            NavAgent.angularSpeed = CurrentAIMoveState.aiMoveData.RotationSpeed;
        }

        public virtual void Move(Vector3 position)
        {
            NavAgent.SetDestination(position);
        }
        
        public bool ReachedDestination()
        {
            OnReachedDestination?.Invoke();
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

    }

    public class AIMoveState
    {
        [BoxGroup("Data")]
        public AIMoveData aiMoveData;
    }

}