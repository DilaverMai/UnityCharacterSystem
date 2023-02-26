using _GAME_.Scripts.UpgradeSystem;
using Sirenix.OdinInspector;
using UnityEngine;

public class UpgradeTrigger : MonoBehaviour
{
   public int UpgradeID;
   public ItemsItemNames ItemName;
   
   [Button]
   public void Triger()
   {
      var upgradeManager = FindObjectOfType<UpgradeManager>();
      var upgrade = upgradeManager.GetUpgradeWithID(UpgradeID);
      upgradeManager.AddCountToUpgrade(upgrade,ItemName,1);
   }
   
   [Button]
   public void LogLevel(int lvl)
   {
      var upgradeManager = FindObjectOfType<UpgradeManager>();
      var upgrade = upgradeManager.GetUpgradeWithID(UpgradeID);
   }
}
