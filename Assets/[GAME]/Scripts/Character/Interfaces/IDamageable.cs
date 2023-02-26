using System;
using _GAME_.Scripts.Character.Abstracs;
using UnityEngine;

namespace _GAME_.Scripts.Character.Interfaces
{
    public interface IDamageable
    {
        void TakeDamage(ref IDamageable healthSystem, int damage,ref CharacterTypes characterType);
        Transform transform { get; }
    }
    
    public interface ISpecificDamageable<T>:IDamageable where T : Enum
    {
        void TakeDamage(ref ISpecificDamageable<T> healthSystem, int damage,ref CharacterTypes characterType);
    }
}