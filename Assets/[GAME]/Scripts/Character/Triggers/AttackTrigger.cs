using Character;
using UnityEngine;
namespace _GAME_.Scripts.Character.Triggers
{
    public class AttackTrigger : MonoBehaviour
    { 
        public Attacker<EnemyAnimationList> attacker;
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<HealthSystem>(out var health))
            {
                //attacker.CheckForAttack(health);
            }
        }
    }
}