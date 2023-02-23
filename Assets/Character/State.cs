using System.Collections;

namespace Character
{
    [System.Serializable]
    public class State: IAttackable
    {
        public AttackerData attackerData;
        public UsingSkillData usingSkillData;
        
        public void Attack(IDamageable healthSystem, float targetDistance)
        {
            
        }

        public IEnumerator AttackCoroutine(IDamageable healthSystem)
        {
            yield return null;
        }
    }
}