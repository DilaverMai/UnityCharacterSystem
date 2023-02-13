using UnityEngine;

namespace Character
{
    [CreateAssetMenu(menuName = "Create AttackerData", fileName = "AttackerData", order = 0)]
    public class AttackerData:ScriptableObject
    {
        public int Damage;
        public float AttackDelay;
        public float AttackRange;
    }
}