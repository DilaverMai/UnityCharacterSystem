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
      upgradeManager.AddCountToUpgrade(0,ItemName);
   }
   
   UpgradeManager upgradeManager;

   private void Sub()
   {
      upgradeManager.GetUpgradeWithName("EvLevel").UpgradeEffect.AddListener(LevelUpdates);
   }

   private void LevelUpdates(int arg0)
   {
      switch (arg0)
      {
         case 1:
            break;
      }
   }

   [Button]
   public void LogLevel(int lvl)
   {
      var upgradeManager = FindObjectOfType<UpgradeManager>();
      var upgrade = upgradeManager.GetUpgradeWithID(UpgradeID);
   }
}
