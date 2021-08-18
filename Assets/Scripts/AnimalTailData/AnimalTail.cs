using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AnimalTail : MonoBehaviour, IPointerDownHandler

{
    [SerializeField]
    private Image sprite;

    [SerializeField]
    private Image shine;

    private Canvas canvas;

    private RectTransform rectTransform;

    private CanvasGroup canvasGroup;

    public bool isMatch = false;

    public AnimalType animalType;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        setShine(false);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        GameManager.Instance.onAnimalTailChoosen(animalType);
        StartCoroutine(switchOnShineAndSwitchOffShine());
    }

    public void setData(AnimalIconData tailData, Canvas c)
    {
        sprite.sprite = tailData.TailSprite;
        canvas = c;
        animalType = tailData.AnimalType;
    }

    public void setShine(bool val)
    {
        shine.gameObject.SetActive(val);
    }

    IEnumerator switchOnShineAndSwitchOffShine()
    {
        setShine(true);
        yield return new WaitForSeconds(1f);
        setShine(false);
    }
}
