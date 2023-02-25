using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;

namespace Character
{
    public class CharacterMoveWithNavMeshAndRoute : CharacterMoveWithNavMesh, IRoute
    {
        [BoxGroup("Data")]
        public WayPoint WayPoints;
        [BoxGroup("Event")]
        public UnityEvent OnNextWayPoint;
    
        public override void Move(Vector3 position)
        {
            NavAgent.SetDestination(position);

            if (ReachedDestination())
                NextWayPoint();
        }
    
        public void RouteMover()
        {
            Move(WayPoints.CurrentWayPoint.Position);
        }
    
        public Vector3 NextWayPoint()
        {
            OnNextWayPoint?.Invoke();
            return WayPoints.NextWayPoint();
        }

        public void OnDrawGizmos()
        {
            if(WayPoints.WayPoints != null)
                WayPoints.GizmosDraw(transform);
        }
    }
}