using System;
using _GAME_.Scripts.Character.Abstracs;
using UnityEngine;

namespace Character
{
    public interface IDamageable
    {
        void TakeDamage(ref IDamageable healthSystem, int damage,ref CharacterTypes characterType);
        Transform transform { get; }
    }
    
    public interface ISpecificDamageable<T> where T : Enum
    {
        void TakeDamage(ref ISpecificDamageable<T> healthSystem, int damage,ref CharacterTypes characterType);
        Transform transform { get; }
    }
}