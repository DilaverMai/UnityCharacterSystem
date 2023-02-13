using System.Collections.Generic;
using Character;

public class AttackerWithState : Attacker, IStateAttacker
{
    public State CurrentState;
    public Dictionary<string,State> States = new Dictionary<string, State>();


    public void ChangeState(string stateName)
    {
        if (States.ContainsKey(stateName))
            CurrentState = States[stateName];
    }
}