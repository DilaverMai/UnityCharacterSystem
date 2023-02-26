using _GAME_.Scripts.Character.Abstracs;
using Character;

public enum EnemyAnimationList
{
    None,
    Idle,
    Walk,
    Attack,
    Hit,
    Death
}

public class EnemyAnimationSystem : CharacterAnimationSystem<EnemyAnimationList>
{
    
}