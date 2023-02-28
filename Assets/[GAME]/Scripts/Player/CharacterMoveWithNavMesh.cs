using System;
using System.Collections.Generic;
using _GAME_.Scripts.Character;
using _GAME_.Scripts.Character.Interfaces;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.AI;

namespace _GAME_.Scripts.Player
{
    [RequireComponent((typeof(NavMeshAgent)))]
    [System.Serializable]
    public class CharacterMoveWithNavMesh:MonoBehaviour
    {
        public List<AIMoveData> aiMoveStates;
        [ShowInInspector,ReadOnly]
        private AIMoveStateWithNav currentAIMoveStateWithNav;
        [ShowInInspector,ReadOnly]
        private List<AIMoveStateWithNav> _aiMoveStates = new List<AIMoveStateWithNav>();
        
        private IFinder<IDamageable> _damageableFinder;
        public IFinder<IDamageable> DamageableFinder
        {
            get
            {
                if (_damageableFinder == null)
                    _damageableFinder = GetComponent<IFinder<IDamageable>>();
                return _damageableFinder;
            }
            set => _damageableFinder = value;
        }

        private void Awake()
        {
            foreach (var state in aiMoveStates)
            {
                switch (state.moveState)
                {
                    case CharacterAIMoveState.Idle:
                        break;
                    case CharacterAIMoveState.Patrol:
                        var patrolState = new AIRoute(state,transform);
                        _aiMoveStates.Add(patrolState);
                        break;
                    case CharacterAIMoveState.Chase:
                        break;
                    case CharacterAIMoveState.Attack:
                        break;
                    case CharacterAIMoveState.Flee:
                        break;
                    case CharacterAIMoveState.Dead:
                        break;
                    case CharacterAIMoveState.Prowl:
                        var Prowl = new AIProwl(state);

                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
            
            currentAIMoveStateWithNav = _aiMoveStates[0];
        }
        
    }
}