using System.Collections;
using _GAME_.Scripts.Character.Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;

namespace Character
{
    [RequireComponent((typeof(NavMeshAgent)))]
    [System.Serializable]
    public class CharacterMoveWithNavMesh:MonoBehaviour, IInitializable, IMovable
    {
        [BoxGroup("Data")]
        public MoveData MoveData;
        [BoxGroup("Data")]
        public NavMeshAgent NavAgent;
        [BoxGroup("Event")]
        public UnityEvent OnReachedDestination;

        private void Awake()
        {
            NavAgent = GetComponent<NavMeshAgent>();
        }

        public void Initialize()
        {
            NavAgent.speed = MoveData.Speed;
            NavAgent.stoppingDistance = MoveData.StoppingDistance;
            NavAgent.angularSpeed = MoveData.RotationSpeed;
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
    
}