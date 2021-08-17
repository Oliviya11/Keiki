using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AnimalTail : MonoBehaviour, IPointerDownHandler, IBeginDragHandler, IEndDragHandler, IDragHandler

{
    [SerializeField]
    private Image sprite;

    private Canvas canvas;

    private RectTransform rectTransform;

    private CanvasGroup canvasGroup;

    public bool isMatch = false;

    public AnimalType animalType;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = .6f;
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;
        Debug.LogError("On End Drag");
    }

    public void OnPointerDown(PointerEventData eventData)
    {

    }

    public void setData(AnimalIconData tailData, Canvas c)
    {
        sprite.sprite = tailData.TailSprite;
        canvas = c;
        animalType = tailData.AnimalType;
    }
}
