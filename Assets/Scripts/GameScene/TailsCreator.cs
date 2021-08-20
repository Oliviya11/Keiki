using System;
using System.Collections.Generic;
using UnityEngine;

public class TailsCreator : MonoBehaviour
{
    [SerializeField]
    private RectTransform leftPanel, rightPanel;
    [SerializeField]
    private GameObject tailPrefab;
    [SerializeField]
    private AnimalDataPrefab animalDataPrefab;
    [SerializeField]
    private Canvas canvas;

    List<GameObject> tails = new List<GameObject>();
    Rect currentSafeArea;
    ScreenOrientation currentOrientation;

    public void Start()
    {
        createTails();
    }

    void createTails()
    {
        clearTails();
        Rect safeArea = Screen.safeArea;
        Array values = Enum.GetValues(typeof(AnimalType));

        for (int i = 0; i < values.Length; ++i)
        {
            Transform parent = leftPanel.transform;
            if (i >= 3)
            {
                parent = rightPanel.transform;
            }
            GameObject tail = Instantiate(tailPrefab, Vector3.zero, Quaternion.identity, parent);
            tails.Add(tail);
            RectTransform tailTransform = tail.GetComponent<RectTransform>();
            AnimalTail animalTail = tail.GetComponent<AnimalTail>();

            AnimalIconData animalTailData = animalDataPrefab.getAnimalData((AnimalType)values.GetValue(i));

            if (animalTailData != null)
            {
                animalTail.setData(animalTailData, canvas);
                if (GameManager.Instance.choosenAnimalType == animalTail.animalType)
                {
                    GameManager.Instance.rightAnimalTail = animalTail;
                }
                tailTransform.anchoredPosition = Vector2.zero;

                GameManager.Instance.pulsingTails.Add(tail.GetComponent<Pulsing>());

                setPositionToTailTransform(i, tailTransform);
            }
        }

        currentSafeArea = safeArea;
        currentOrientation = Screen.orientation;
    }

    void setPositionToTailTransform(int i, RectTransform tailTransform)
    {
        if (i == 0)
        {
            tailTransform.anchorMin = new Vector2(0.65f, 0.8f);
            tailTransform.anchorMax = new Vector2(0.65f, 0.8f);
        }
        else if (i == 1)
        {
            tailTransform.anchorMin = new Vector2(0.7f, 0.5f);
            tailTransform.anchorMax = new Vector2(0.7f, 0.5f);
        }
        else if (i == 2)
        {
            tailTransform.anchorMin = new Vector2(0.65f, 0.2f);
            tailTransform.anchorMax = new Vector2(0.65f, 0.2f);
        }
        else if (i == 3)
        {
            tailTransform.anchorMin = new Vector2(0.35f, 0.8f);
            tailTransform.anchorMax = new Vector2(0.35f, 0.8f);
        }
        else if (i == 4)
        {
            tailTransform.anchorMin = new Vector2(0.3f, 0.5f);
            tailTransform.anchorMax = new Vector2(0.3f, 0.5f);
        }
        else if (i == 5)
        {
            tailTransform.anchorMin = new Vector2(0.35f, 0.2f);
            tailTransform.anchorMax = new Vector2(0.35f, 0.2f);
        }
    }

    void clearTails()
    {
        for (int i = 0; i < tails.Count; ++i)
        {
            Destroy(tails[i]);
        }

        tails.Clear();
    }

    void Update()
    {
        if (currentOrientation != Screen.orientation || currentSafeArea != Screen.safeArea)
        {
            createTails();
        }
    }
}
