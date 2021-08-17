using UnityEngine;
using UnityEngine.EventSystems;

public class TailSlot : MonoBehaviour, IDropHandler
{
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            GameObject pointerDrag = eventData.pointerDrag;
            AnimalTail animalTail = pointerDrag.GetComponent<AnimalTail>();
            RectTransform rt = eventData.pointerDrag.GetComponent<RectTransform>();
            if (animalTail.animalType == GameManager.Instance.choosenAnimal)
            {
                rt.position = GetComponent<RectTransform>().position;
            } else
            {
                Debug.LogError("Fly away");
            }
            
        }
    }
}
