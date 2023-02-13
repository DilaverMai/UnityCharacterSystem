using UnityEngine;

namespace Character
{
    public interface IDamageable
    {
        void TakeDamage(ref IDamageable healthSystem, int damage,ref CharacterTypes characterType);
        Transform transform { get; }
    }
}