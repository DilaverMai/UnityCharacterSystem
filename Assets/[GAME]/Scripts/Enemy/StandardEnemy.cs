using _GAME_.Scripts.Character;
using _GAME_.Scripts.Character.Abstracs;
using Character;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using _GAME_.Scripts.Character.Interfaces;
using UnityEngine;

namespace _GAME_.Scripts.Enemy
{
    public class StandardEnemy : EnemyBase
    {
        [BoxGroup("Systems"),ReadOnly]
        public IAttacker<EnemyAnimationList> AttackSystem;
        [BoxGroup("Systems"),ReadOnly]
        public IMovable MoveSystem;
        [BoxGroup("Systems"),ReadOnly]
        public IFinder<IDamageable> finderWithLayer;
        [BoxGroup("Systems"),ReadOnly]
        public IAnimable<EnemyAnimationList> AnimationSystemSystem;
        [BoxGroup("Systems"),ReadOnly]
        public IDamageable HealthSystem;

        private IUpdater[] _updaters;
        
        public List<EnemyState> EnemyStates;

        private void Initialize()
        {
            finderWithLayer = GetComponent<IFinder<IDamageable>>();
            HealthSystem = GetComponent<IDamageable>();
            AttackSystem = GetComponent<IAttacker<EnemyAnimationList>>();
            AnimationSystemSystem = GetComponent<IAnimable<EnemyAnimationList>>();
            MoveSystem = GetComponent<IMovable>();
        }

        private void AllRunInitialize()
        {
            _updaters = GetComponentsInChildren<IUpdater>();
            var componentsInChildren = GetComponentsInChildren<IInitializable>();
            
            foreach (var init in componentsInChildren)
                init.Initialize();
            
            StartCoroutine(OnUpdater());
        }

        protected override void OnSpawn()
        {
            Initialize();
            AllRunInitialize();
            StartCoroutine(OnUpdater());
        }

        protected override void OnDeath()
        {
            CharacterState = CharacterStates.Die;
        }
        
        private IEnumerator OnUpdater()
        {
            while (CharacterState != CharacterStates.Die)
            {
                
                yield return new WaitForFixedUpdate();
            }
        }
        
    }
}