using UnityEngine;

namespace Character
{
    public class AttackTrigger : MonoBehaviour
    { 
        public Attacker attacker;
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent<HealthSystem>(out var health))
            {
                attacker.Attack(health);
            }
        }
    }
}