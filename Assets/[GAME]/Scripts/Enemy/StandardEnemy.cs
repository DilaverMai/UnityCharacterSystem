using _GAME_.Scripts.Character;
using _GAME_.Scripts.Character.Abstracs;
using Character;
using Sirenix.OdinInspector;
using System.Collections;
<<<<<<< Updated upstream
using _GAME_.Scripts.Character.Interfaces;
using UnityEngine;

=======
using UnityEngine;
>>>>>>> Stashed changes
namespace _GAME_.Scripts.Enemy
{
    public class StandardEnemy : EnemyBase
    {
        [BoxGroup("Systems"),ReadOnly]
        public HealthSystem HealthSystem;
        [BoxGroup("Systems"),ReadOnly]
        public Attacker<EnemyAnimationList> AttackSystem;
        [BoxGroup("Systems"),ReadOnly]
        public EnemyAnimationSystem AnimationSystemSystem;
        [BoxGroup("Systems"),ReadOnly]
        public IMovable MoveSystem;
        [BoxGroup("Systems"),ReadOnly]
        public DamageableFinderWithLayer finderWithLayer;
        private IUpdater[] _updaters;
        
        private void Initialize()
        {
            finderWithLayer = GetComponent<DamageableFinderWithLayer>();
            HealthSystem = GetComponent<HealthSystem>();
            AttackSystem = GetComponent<Attacker<EnemyAnimationList>>();
            AnimationSystemSystem = GetComponent<EnemyAnimationSystem>();
            MoveSystem = GetComponent<CharacterMoveWithNavMeshAndRoute>();
            
            HealthSystem.OnDeath.AddListener(OnDeath);
            HealthSystem.OnDeath.AddListener(() => AnimationSystemSystem.PlayAnimation(EnemyAnimationList.Death));
            HealthSystem.OnHit.AddListener(() =>  AnimationSystemSystem.PlayAnimation(EnemyAnimationList.Hit)) ;
            // AttackSystem.attackEvent.AddListener(() => AnimationSystemSystem.PlayAnimation(EnemyAnimationList.Attack));
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
<<<<<<< Updated upstream


        IEnumerator OnUpdater()
        {
            while (CharacterState != CharacterStates.Die)
            {
                yield return new WaitForFixedUpdate();
                foreach (var updater in _updaters)
                    updater.OnUpdate();
=======
        
        private IEnumerator OnUpdater()
        {
            while (CharacterState != CharacterStates.Die)
            {
                var findTarget = finderWithLayer.FindTarget();
                if (findTarget != null)
                {
                    AttackSystem.CheckForAttack(
                        findTarget,
                        findTarget.transform.position);
                }
                yield return new WaitForFixedUpdate();
>>>>>>> Stashed changes
            }
        }
        
    }
    
}