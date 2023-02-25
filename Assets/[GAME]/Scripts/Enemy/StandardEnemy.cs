using _GAME_.Scripts.Character;
using _GAME_.Scripts.Character.Abstracs;
using Character;
using Sirenix.OdinInspector;
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
        public CharacterMoveWithNavMeshAndRoute MoveSystem;
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
        }

        protected override void OnSpawn()
        {
            Initialize();
            AllRunInitialize();
        }

        protected override void OnDeath()
        {
            CharacterState = CharacterStates.Die;
        }

        private void Update()
        {
            if(CharacterState == CharacterStates.Die) return;
            //
            // var find = finderWithLayer.FindTarget();
            //
            // if (find != null)
            // {
            //     MoveSystem.Move(finderWithLayer.GetTargetPosition());
            //     if(MoveSystem.ReachedDestination())
            //         AttackSystem.CheckForAttack(finderWithLayer.FindTarget(), finderWithLayer.TargetDistance);
            // }
            // else MoveSystem.RouteMover();
            //
            // foreach (var updater in _updaters)
            //     updater.OnUpdate();
        }
        
    }
    
}