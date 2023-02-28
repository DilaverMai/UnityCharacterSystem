using _GAME_.Scripts.Character;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _GAME_.Scripts.Player
{
    public class AIRoute: AIMoveStateWithNav, IRoute
    {
        [ShowInInspector]
        private readonly Vector3[] routes;
        private readonly Transform thisTransform;
        [ShowInInspector]
        private Vector3 currentPoint => routes[currentRouteIndex];
        private int currentRouteIndex;

        public AIRoute(AIMoveData aiMoveData,Transform thisTransform) : base(aiMoveData)
        {
            routes = aiMoveData.routes;
            this.thisTransform = thisTransform;
        }
        
        public Vector3 NextWayPoint()
        {
            if (routes.Length == 0)
                return default;

            currentRouteIndex++;
            if(currentRouteIndex > routes.Length-1)
                currentRouteIndex = 0;
            
            return currentPoint;
        }

        public Vector3 GetCurrentRoutePoint()
        {
            if (ReachedDestination())
                return NextWayPoint();
                
            return currentPoint;
        }

        public override void Move(Vector3 targetPosition = default)
        {
            if (ReachedDestination())
                return;
            
            navMeshAgent.SetDestination(GetCurrentRoutePoint());
        }

        public bool ReachedDestination()
        {
            return Vector3.Distance(thisTransform.position,currentPoint) <= stoppingDistance;
        }
    }
}