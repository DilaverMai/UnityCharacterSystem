using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace _GAME_.Scripts.UpgradeSystem
{
	[CreateAssetMenu(fileName = "RequirementsForUpgradeData", menuName = "UpgradeSystem/RequirementsForUpgradeData", order = 0)]
	public class RequirementsForUpgradeData : ScriptableObject
	{
		[Serializable]
		public class RequirementLevel
		{
			public ItemsItemNames ItemName;
			public int RequiredAmount;
			public int CurrentAmount;
			public bool IsRequirementMet()
			{
				return CurrentAmount >= RequiredAmount;
			}
			
			public bool AddItem(int amount)
			{
				CurrentAmount += amount;
				return IsRequirementMet();
			}
		}
		
		[Serializable]
		public class RequirementLevelArray
		{
			public int Level;
			public List<RequirementLevel> RequirementsForUpgrade;
		}
		
		public string Name;
		public int UpgradeID;
		public RequirementLevelArray[] RequirementsForUpgrade;
	}
}