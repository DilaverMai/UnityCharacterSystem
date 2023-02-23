using System;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;
using Object = UnityEngine.Object;

namespace UpgradeSystem
{
    [Serializable]
    public class Upgrade
    {
        public string requirementTitle;
        public int upgradeLevel;
        public List<RequirementList> requirementList = new List<RequirementList>();
        [ReadOnly]
        public List<Requirement> upgradeDatas = new List<Requirement>();
        public UpgradeEffect upgradeEffect;
        public void Initialized()
        {
            upgradeLevel = 0;
            upgradeDatas.Clear();
            
            foreach (var requirement in requirementList)
            {
                var data = new Requirement();
                data.currentCount = 0;
                data.requirementValue = requirement.requirementList[upgradeLevel].requirementValue;
                data.requirementType = requirement.requirementList[upgradeLevel].requirementType;
                upgradeDatas.Add(data);
            }
        }
        
        public bool IsFinish()
        {
            return upgradeDatas.Count == 0;
        }
        
        public void AddItem(ItemsItemNames itemName,int count = 1)
        {
            foreach (var requirement in upgradeDatas.Where(requirement => requirement.requirementType == itemName))
            {
                if (requirement.AddCount(count))
                {
                    upgradeDatas.Remove(requirement);
                }

                if (IsFinish())
                {
                    upgradeEffect.OnUpgrade?.Invoke();
                    Object.FindObjectOfType<UpgradeManager>().RemoveUpgrade(this);
                }
                break;
            }
        }
        
        public bool NextLevel()
        {
            var check = upgradeLevel + 1;
            if(check == requirementList.Count)
                return false;

            upgradeLevel++;
            return true;
        }
        
        public bool CurrentLevelIsMax()
        {
            return upgradeLevel == requirementList.Count;
        }
        
        public bool CurrentUpgradeIsUpgradeable()
        {
            return upgradeDatas[upgradeLevel].IsRequirementAvailable();
        }
        
        public void UpgradeNow()
        {
            if (!CurrentUpgradeIsUpgradeable()) return;
            
            upgradeEffect.OnUpgrade.Invoke();
            NextLevel();
        }
        
        public bool IsRequirementAvailable()
        {
            return upgradeDatas.TrueForAll(requirement => requirement.IsRequirementAvailable());
        }
        
    }
}