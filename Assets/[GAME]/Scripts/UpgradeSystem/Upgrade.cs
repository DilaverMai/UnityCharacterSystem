using UnityEngine;
using UnityEngine.Events;
using static _GAME_.Scripts.UpgradeSystem.RequirementsForUpgradeData;

namespace _GAME_.Scripts.UpgradeSystem
{
	[System.Serializable]
	public class Upgrade
	{
		public string Name;
		public int UpgradeID;
		
		public int CurrentLevel;
		public int MaxLevel;
	
		public RequirementLevelArray[] RequirementsForUpgrade;
		
		public UnityEvent<int> UpgradeEffect;

		public Upgrade(RequirementsForUpgradeData data)
		{
			if (data == null) return;
			
			Name = data.Name;
			UpgradeID = data.UpgradeID;
			
			MaxLevel = data.RequirementsForUpgrade.Length;
			RequirementsForUpgrade = data.RequirementsForUpgrade;
		}
		
		public bool NextLevel()
		{
			MaxLevel = RequirementsForUpgrade.Length;
			CurrentLevel++;
			return CurrentLevel <= MaxLevel;
		}
		
		public bool IsEmpty()
		{
			return RequirementsForUpgrade.Length == 0;
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
				if (upgradeItem.ItemName == itemName)
				{
					if (upgradeItem.AddItem(amount))
					{
						Debug.Log("Requirement met");
						//currentRequirements.RequirementsForUpgrade.Remove(upgradeItem);
						return true;
					}
				}
			}

			return false;
		}
	}
}