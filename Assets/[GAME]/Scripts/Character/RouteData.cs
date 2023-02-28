using UnityEngine;
namespace _GAME_.Scripts.Character
{
	[System.Serializable]
	public class RouteData
	{
		public struct Data
		{
			public Vector3[] Points;
			public float WaitTime;
		}
        
		public Data[] PointDataList;
	}
}