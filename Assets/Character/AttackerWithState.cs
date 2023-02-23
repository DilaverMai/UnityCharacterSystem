using System.Collections.Generic;
using Sirenix.OdinInspector;

namespace Character
{
    public class AttackerWithState : Attacker, IStateAttacker
    {
        [BoxGroup("State")]
        public State CurrentState;
        [BoxGroup("State")]
        [DictionaryDrawerSettings(DisplayMode = DictionaryDisplayOptions.Foldout)]
        public Dictionary<string,State> States = new Dictionary<string, State>();


        public void ChangeState(string stateName)
        {
            if (States.ContainsKey(stateName))
                CurrentState = States[stateName];
        }
    }
}