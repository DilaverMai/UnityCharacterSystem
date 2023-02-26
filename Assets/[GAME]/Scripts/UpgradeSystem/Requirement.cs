namespace _GAME_.Scripts.UpgradeSystem
{
    [System.Serializable]
    public class Requirement
    {
        public ItemsItemNames requirementType = ItemsItemNames.None;
        public int requirementValue;
        public int currentCount;
        
        public bool IsRequirementAvailable()
        {
            return currentCount >= requirementValue;
        }
        
        public void Reset()
        {
            currentCount = 0;
        }
        
        public bool AddCount(int count)
        {
            currentCount += count;
            
            return IsRequirementAvailable();
        }
    }
}