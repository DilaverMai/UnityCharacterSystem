using _GAME_.Scripts.Character;
using _GAME_.Scripts.Player;
using UnityEngine;

public class AIMoveToTargetStateWithNav : AIMoveStateWithNav
{
    public AIMoveToTargetStateWithNav(AIMoveData aiMoveData) : base(aiMoveData)
    {
        
    }

    public override void Move(Vector3 targetPosition = default)
    {
        NavAgent.SetDestination(targetPosition);
    }
}
