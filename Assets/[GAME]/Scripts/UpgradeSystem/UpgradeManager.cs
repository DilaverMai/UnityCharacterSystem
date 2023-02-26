using System.Collections.Generic;
using UnityEngine;

namespace _GAME_.Scripts.UpgradeSystem
{
	public class UpgradeManager : MonoBehaviour
	{
		public List<RequirementsForUpgradeData> RequirementsForUpgradeData;
		public List<Upgrade> Upgrades;

		private void Awake()
		{
			if (RequirementsForUpgradeData == null) return;
			
			Upgrades = new List<Upgrade>();
		
			foreach (var data in RequirementsForUpgradeData)
			{
				Upgrades.Add(new Upgrade(data));
			}
		}

		#region Search 

		public Upgrade GetUpgradeWithID(int upgradeID)
		{
			return Upgrades.Find(upgrade => upgrade.UpgradeID == upgradeID);
		}
		
		public Upgrade GetUpgradeWithName(string upgradeName)
		{
			return Upgrades.Find(upgrade => upgrade.Name == upgradeName);
		}

		#endregion
		
		#region Level
		
		public bool UpgradeLevel(Upgrade upgrade,int count = 1)
		{
			if (upgrade == null) return false;
			if (upgrade.CurrentLevel >= upgrade.MaxLevel) return false;
			if(upgrade.CurrentLevel + count > upgrade.MaxLevel) return false;
			
			upgrade.CurrentLevel+= count;
			return true;
		}
		
		public bool ResetUpgradeLevel(Upgrade upgrade)
		{
			if (upgrade == null) return false;
			upgrade.CurrentLevel = 0;
			
			return true;
		}
		
		#endregion
		
		#region Data
		
		public void AddCountToUpgrade(Upgrade upgrade,ItemsItemNames itemName,int count = 1)
		{
			if (upgrade == null) return;

			if (!upgrade.AddItem(itemName, count)) return;
			if (upgrade.NextLevel()) return;
			
			Debug.Log("Upgrade complete");
			Upgrades.Remove(upgrade);
		}
		
		public void AddCountToUpgradeByID(int upgrade,ItemsItemNames itemName,int count = 1)
		{
			var upgradeData = GetUpgradeWithID(upgrade);
			
			if (upgradeData == null) return;
		
			if (!upgradeData.AddItem(itemName, count)) return;
			if (upgradeData.NextLevel()) return;
			
			Debug.Log("Upgrade complete");
			Upgrades.Remove(upgradeData);
		}
		
		public void AddCountToUpgradeByName(string upgrade,ItemsItemNames itemName,int count = 1)
		{
			var upgradeData = GetUpgradeWithName(upgrade);
			
			if (upgradeData == null) return;
		
			if (!upgradeData.AddItem(itemName, count)) return;
			if (upgradeData.NextLevel()) return;
			
			Debug.Log("Upgrade complete");
			Upgrades.Remove(upgradeData);
		}
		
		#endregion
	}
}