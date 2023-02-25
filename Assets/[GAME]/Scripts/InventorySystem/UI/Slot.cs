using UnityEngine;
using UnityEngine.EventSystems;

namespace InventorySystem.UI
{
    public class Slot : DraggableSlot, IPointerClickHandler
    {
        public int[,] SlotPosition;

        public void OnPointerClick(PointerEventData eventData)
        {
            
        }
    }
}

public class DraggableSlot : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public void OnBeginDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        throw new System.NotImplementedException();
    }
}
