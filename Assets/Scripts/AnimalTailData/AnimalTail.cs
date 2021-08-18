using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AnimalTail : MonoBehaviour, IPointerDownHandler

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

    public void OnPointerDown(PointerEventData eventData)
    {
        GameManager.Instance.onAnimalTailChoosen(animalType);
    }

    public void setData(AnimalIconData tailData, Canvas c)
    {
        sprite.sprite = tailData.TailSprite;
        canvas = c;
        animalType = tailData.AnimalType;
    }
}
