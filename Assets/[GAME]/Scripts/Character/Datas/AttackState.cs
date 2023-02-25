using System;
using System.Collections;
using _GAME_.Scripts.Character.Abstracs;
using _GAME_.Scripts.Character.Datas;
using _GAME_.Scripts.Character.Interfaces;
using Character;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _GAME_.Scripts.Character.Data
{
	public abstract class AttackState<T> where T : Enum
	{
		protected IMovable movable;
		protected CharacterAnimationSystem<T> animationSystem;
		protected CharacterTypes characterType;
		protected readonly Transform thisTransform;

		public StateAttackData<T> StateAttackData;

		protected AttackState(Attacker<T>.RefData data, StateAttackData<T> stateAttackData)
		{
			this.movable = data.movable;
			this.animationSystem = data.animationSystem;
			this.characterType = data.characterType;
			this.thisTransform = data.transform;
			StateAttackData = stateAttackData;
		}

		[ShowInInspector, ReadOnly, BoxGroup("Attack Debug")]
		private bool _isAttacking => _attackCoroutine != null;
		[ShowInInspector, ReadOnly, BoxGroup("Attack Debug")]
		private Coroutine _attackCoroutine;
		
		public virtual IEnumerator Attack(IDamageable healthDamageable)
		{
			yield return new WaitForSeconds(StateAttackData.AttackDelay);
			Attack(ref healthDamageable);
			healthDamageable.TakeDamage(ref healthDamageable, StateAttackData.Damage, ref characterType);
			yield return new WaitForSeconds(StateAttackData.AttackLoadTime);
		}

		protected abstract void Attack(ref IDamageable healthDamageable);
		
		public bool CanAttack(ref Vector3 targetDistance)
		{
			return CanHit(ref targetDistance) & !_isAttacking;
		}

		protected abstract bool CanHit(ref Vector3 target);
		
		protected virtual float GetDistance(ref Vector3 targetDistance)
		{
			return Vector3.Distance(thisTransform.position, targetDistance);
		}

		protected virtual float GetAngle(ref Vector3 targetDistance)
		{
			return Vector3.Angle(thisTransform.position, targetDistance);
		}

		protected virtual float YOffset(ref float targetYPos)
		{
			return thisTransform.position.y - targetYPos;
		}
	}

}