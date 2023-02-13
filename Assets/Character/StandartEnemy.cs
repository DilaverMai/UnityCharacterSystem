using Sirenix.OdinInspector;

namespace Character
{
    public class StandartEnemy : EnemyBase
    {
        [BoxGroup("Systems"),ReadOnly]
        public HealthSystem HealthSystem;
        [BoxGroup("Systems"),ReadOnly]
        public Attacker AttackSystem;
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
            AttackSystem = GetComponent<Attacker>();
            AnimationSystemSystem = GetComponent<EnemyAnimationSystem>();
            MoveSystem = GetComponent<CharacterMoveWithNavMeshAndRoute>();
            
            HealthSystem.OnDeath.AddListener(OnDeath);
            HealthSystem.OnDeath.AddListener(() => AnimationSystemSystem.PlayAnimation(EnemyAnimationList.Death));
            HealthSystem.OnHit.AddListener(() =>  AnimationSystemSystem.PlayAnimation(EnemyAnimationList.Hit)) ;
            AttackSystem.OnAttack.AddListener(() => AnimationSystemSystem.PlayAnimation(EnemyAnimationList.Attack));
        }

        private void AllRunInitialize()
        {
            _updaters = GetComponentsInChildren<IUpdater>();
            var componentsInChildren = GetComponentsInChildren<IInitializable>();
            
            foreach (var init in componentsInChildren)
                init.Initialize();
        }
        
        public override void OnSpawn()
        {
            Initialize();
            AllRunInitialize();
        }
        
        public override void OnDeath()
        {
            CharacterState = CharacterStates.Die;
        }

        private void Update()
        {
            if(CharacterState == CharacterStates.Die) return;
            
            var find = finderWithLayer.FindTarget();

            if (find != null)
            {
                MoveSystem.Move(finderWithLayer.GetTargetPosition());
                if(MoveSystem.ReachedDestination())
                    AttackSystem.Attack(finderWithLayer.FindTarget(), finderWithLayer.TargetDistance);
            }
            else MoveSystem.RouteMover();
            
            foreach (var updater in _updaters)
                updater.OnUpdate();
        }
        
    }
    
}