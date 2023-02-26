using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _GAME_.Scripts.UpgradeSystem
{
    public class UpgradeManager : MonoBehaviour
    {
        public List<Upgrade> upgradeList;

        private void Start()
        {
            foreach (var upgrade in upgradeList)
            {
                upgrade.Initialized();
            }
        }
        
        public bool IsEmpty()
        {
            return upgradeList.Count == 0;
        }
        
        public void AddItem(string itemName,ItemsItemNames item,int count = 1)
        {
            if (IsEmpty())
            {
                Debug.LogWarning("Empty upgrade list");
                return;
            }
            
            foreach (var x in upgradeList.Where(x => x.requirementTitle == itemName))
            {
                x.AddItem(item);
                break;
            }
        }
        
        public void RemoveUpgrade(Upgrade upgrade)
        {
            upgradeList.Remove(upgrade);
        }
    }
}

