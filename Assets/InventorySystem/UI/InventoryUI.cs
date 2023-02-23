using UnityEngine;
using System.Linq;
namespace InventorySystem.UI
{
    public class InventoryUI : MonoBehaviour
    {
        public Slot[] Slots;
        
        public Slot GetClosestSlot(Vector2 position)
        {
            return Slots.OrderBy(x => Vector2.Distance(x.transform.position, position)).FirstOrDefault();
        }
    }
}
