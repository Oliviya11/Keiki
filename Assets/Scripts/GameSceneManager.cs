using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    [SerializeField]
    private List<AnimalTailData> animalTailData;

    [SerializeField]
    private GameObject tailPrefab;

    [SerializeField]
    private RectTransform leftPanel, rightPanel;

    Rect currentSafeArea;
    ScreenOrientation currentOrientation;

    List<GameObject> tails = new List<GameObject>();

    [SerializeField]
    private Canvas canvas;

    public void Start()
    {
        createChildren();
    }

    void createChildren()
    {
        for (int i = 0; i < tails.Count; ++i)
        {
            Destroy(tails[i]);
        }

        tails.Clear();

        Rect safeArea = Screen.safeArea;

        for (int i = 0; i < 6; ++i)
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
            animalTail.setData(animalTailData[i], canvas);
            tailTransform.localPosition = new Vector3();

            if (i == 0)
            {
                tailTransform.localPosition = new Vector3(leftPanel.sizeDelta.x * 0.15f, 0.3f * Screen.height);
            }
            else if (i == 1)
            {
                tailTransform.localPosition = new Vector3(leftPanel.sizeDelta.x * 0.3f, 0);
            }
            else if (i == 2)
            {
                tailTransform.localPosition = new Vector3(leftPanel.sizeDelta.x * 0.15f, -0.3f * Screen.height);
            }
            else if (i == 3)
            {
                tailTransform.localPosition = new Vector3(-leftPanel.sizeDelta.x * 0.15f, 0.3f * Screen.height);
            }
            else if (i == 4)
            {
                tailTransform.localPosition = new Vector3(-leftPanel.sizeDelta.x * 0.3f, 0);
            }
            else if (i == 5)
            {
                tailTransform.localPosition = new Vector3(-leftPanel.sizeDelta.x * 0.15f, -0.3f * Screen.height);
            }
        }

        currentSafeArea = safeArea;
        currentOrientation = Screen.orientation;
    }

    void Update()
    {
        if (currentOrientation != Screen.orientation || currentSafeArea != Screen.safeArea)
        {
            createChildren();
        }
    }
}
