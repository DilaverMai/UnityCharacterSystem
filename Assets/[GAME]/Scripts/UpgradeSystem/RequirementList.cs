using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UpgradeSystem;

namespace _GAME_.Scripts.UpgradeSystem
{
    [CreateAssetMenu(fileName = "New Requirement List", menuName = "Upgrade System/Requirement List", order = 0)]
    public class RequirementList: ScriptableObject
    {
        [System.Serializable]
        public class RequrimentLevels
        {
            public int requirementLevel;
            public List<Requirement> requirementsLevels = new List<Requirement>();
        }
        
        public List<RequrimentLevels> requirementList = new List<RequrimentLevels>();
    }

    
}