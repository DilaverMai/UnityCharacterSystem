using _GAME_.Scripts.Character;
using _GAME_.Scripts.Player;
using UnityEngine;

public class AIAttackState : AIMoveState
{
    public AIAttackState(AIMoveData aiMoveData) : base(aiMoveData)
    {
    }

    public override Vector3 GetTargetPosition()
    {
        return Vector3.zero;
    }
}
