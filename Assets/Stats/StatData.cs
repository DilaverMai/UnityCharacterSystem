using UnityEngine;

namespace Stats
{
    [CreateAssetMenu(menuName = "Create StatData", fileName = "StatData", order = 0)]
    public class StatData: ScriptableObject
    {
        public string StatName;
        public int Value;
        public int MaxValue;
    }
}