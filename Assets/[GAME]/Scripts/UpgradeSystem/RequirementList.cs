using System;
using System.Collections.Generic;
using InventorySystem;
using UnityEngine;

namespace UpgradeSystem
{
    [CreateAssetMenu(fileName = "New Requirement List", menuName = "Upgrade System/Requirement List", order = 0)]
    public class RequirementList: ScriptableObject
    {
        public List<Requirement> requirementList = new List<Requirement>();
      
    }
}