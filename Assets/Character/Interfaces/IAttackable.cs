using System.Collections;
using Character;

public interface IAttackable
{
    void Attack(IDamageable healthSystem,float targetDistance);
    IEnumerator AttackCoroutine(IDamageable healthSystem);
}