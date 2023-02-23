using InventorySystem.Items;

namespace InventorySystem
{
    public class PlayerLevel : Items.StackableItem
    {
        public override void AddCount(int count)
        {
            base.AddCount(count);
        
        }

        public PlayerLevel(ItemData data) : base(data)
        {
        }
    }
}
