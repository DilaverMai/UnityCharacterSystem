using System;
using _GAME_.Scripts.Character;
using Character;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _GAME_.Scripts.Player
{
    [Serializable]
    public abstract class AIMoveState
    {
        [BoxGroup("Data")]
        public AIMoveData aiMoveData;
        private Vector3 spawnPoint;
        
        public virtual void OnGizmos()
        {
            
        }
    }
}