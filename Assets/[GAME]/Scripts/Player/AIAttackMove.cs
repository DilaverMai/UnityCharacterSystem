using _GAME_.Scripts.Character;
using UnityEngine;
namespace _GAME_.Scripts.Player
{
	public class AIAttackMove: AIMoveStateWithNav
	{
		public AIAttackMove(AIMoveData aiMoveData) : base(aiMoveData) { }
		public override void Move(Vector3 targetPosition = default)
		{
			NavAgent.SetDestination(targetPosition);
		}
	}
}