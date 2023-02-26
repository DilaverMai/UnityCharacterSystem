using System;
using UnityEngine;

namespace _GAME_.Scripts.Player
{
    [Serializable]
    public class RouteStateToPoints : AIMoveState, IRoute
    {
        public int routeIndex;
        public Route[] routes;

        public Vector3 GetDestination()
        {
            return routes[routeIndex].point;
        }

        public void Reset()
        {
            routeIndex = 0;
        }

        public Vector3 NextWayPoint()
        {
            if(routeIndex >= routes.Length)
                routeIndex = 0;
            else routeIndex++;
            
            return routes[routeIndex].point;
        }
    }
}