using System;
using _GAME_.Scripts.Character.Datas;
namespace _GAME_.Scripts.Character.Triggers
{
	public class EnemyAttacker : Attacker<EnemyAnimationList>
	{
		public EnemyAttacker() : base()
		{
		
		}

		private void Start()
		{
			ChangeState(attackStates[0]);
		}
	}
}