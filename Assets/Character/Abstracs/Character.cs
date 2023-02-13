using System;
using Sirenix.OdinInspector;
using Unity.VisualScripting;
using UnityEngine;

namespace Character
{
    public enum CharacterTypes
    {
        Friendly,
        Enemy
    }
    
    public enum CharacterStates
    {
        Idle,
        Move,
        Attack,
        Die
    }
    
    public abstract class CharacterBase: MonoBehaviour
    {
        [BoxGroup("Modeling")]
        public Transform Model3D;
        
        [Button("Create Model"), BoxGroup("Modeling")]
        public virtual void CreateModel()
        {
            var model = Instantiate(Model3D, transform);
           
            model.localPosition = Vector3.zero;
            model.localRotation = Quaternion.identity;
        }
        
        [BoxGroup("Character")]
        public CharacterTypes CharacterType;
        [BoxGroup("Character")]
        public CharacterStates CharacterState;
        protected virtual void OnEnable()
        {
            OnSpawn();
        }
        
        protected virtual void OnDisable()
        {
            OnDeath();
        }

        public abstract void OnDeath();
        public abstract void OnSpawn();
    }
}