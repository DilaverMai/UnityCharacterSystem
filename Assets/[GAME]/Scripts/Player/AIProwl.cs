using _GAME_.Scripts.Character;
using UnityEngine;
namespace _GAME_.Scripts.Player
{
	public class AIProwl : AIMoveStateWithNav
	{
		public float checkRadius;
		public AIProwl(AIMoveData aiMoveData) : base(aiMoveData) { }
		
		public override void Move(Vector3 targetPosition = default)
		{
			NavAgent.SetDestination(CheckPositon());
		}
		
		private Vector3 CheckPositon()
		{
			return Random.insideUnitSphere * checkRadius + NavAgent.transform.position;
		}
	}
	
}