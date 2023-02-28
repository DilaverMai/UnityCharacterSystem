using _GAME_.Scripts.Character;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _GAME_.Scripts.Player
{
    public class AIRoute: AIMoveState, IRoute
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

        public override Vector3 GetTargetPosition()
        {
            if (ReachedDestination())
                return NextWayPoint();
                
            return currentPoint;
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

        public bool ReachedDestination()
        {
            return Vector3.Distance(thisTransform.position,currentPoint) <= stoppingDistance;
        }
        
    }
}