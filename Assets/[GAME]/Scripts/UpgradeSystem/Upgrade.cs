using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;
using Object = UnityEngine.Object;


namespace _GAME_.Scripts.UpgradeSystem
{
	[System.Serializable]
	public class Upgrade
	{
		
		public string Name;
		public int UpgradeID;
		
		public int CurrentLevel;
		public int MaxLevel;
	
		public List<RequirementLevelArray> RequirementsForUpgrade;
		
		public UnityEvent<int> UpgradeEffect;

		public Upgrade(RequirementsForUpgradeData data)
		{
			if (data == null) return;

			var duplicate = Object.Instantiate(data);
			Name = duplicate.Name;
			UpgradeID = duplicate.UpgradeID;
			MaxLevel = duplicate.RequirementsForUpgrade.Count;
			RequirementsForUpgrade = duplicate.RequirementsForUpgrade;
		}
		
		public bool NextLevel()
		{
			MaxLevel = RequirementsForUpgrade.Count;
			CurrentLevel++;
			return CurrentLevel >= MaxLevel;
		}
		
		public bool IsEmpty()
		{
			return RequirementsForUpgrade.Count == 0;
		}
		
		public RequirementLevelArray GetRequirementsForUpgrade(int level)
		{
			return RequirementsForUpgrade[level];
		}
		
		public RequirementLevelArray GetCurrentRequirementsForUpgrade()
		{
			return GetRequirementsForUpgrade(CurrentLevel);
		}
		
		public bool AddItem(ItemsItemNames itemName,int amount)
		{
			var currentRequirements = GetCurrentRequirementsForUpgrade();
			if (currentRequirements == null) return false;
			
			foreach (var upgradeItem in currentRequirements.RequirementsForUpgrade)
			{
				if (upgradeItem.ItemName != itemName) continue;
				
				if (upgradeItem.AddItem(amount)) //true bitmiş demektir
				{
					Debug.Log("Finish Requirement");
					return true;
				}
				
				Debug.Log("Added Item");
				return true;
			}

			Debug.Log("Not Found");
			return false;
		}
	}
}