using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSceneManager : MonoBehaviour
{
    [SerializeField]
    private List<AnimalIconData> animalTailData;

    [SerializeField]
    private GameObject tailPrefab;

    [SerializeField]
    private RectTransform leftPanel, rightPanel;

    Rect currentSafeArea;
    ScreenOrientation currentOrientation;

    List<GameObject> tails = new List<GameObject>();

    [SerializeField]
    private Canvas canvas;

    [Header("Animations prefabs"), SerializeField]
    private GameObject pigPrefab;
    [SerializeField]
    private GameObject catPrefab;
    [SerializeField]
    private GameObject dogPrefab;
    [SerializeField]
    private GameObject mousePrefab;
    [SerializeField]
    private GameObject cowPrefab;
    [SerializeField]
    private GameObject horsePrefab;

    public void Awake()
    {
        createAnimal();
    }

    void createAnimal()
    {
        GameObject prefab;
        AnimalType animalType = GameManager.Instance.choosenAnimal;
        if (animalType == AnimalType.Pig)
        {

        } else if (animalType == AnimalType.Cat)
        {
            GameObject a = Instantiate(catPrefab, Vector3.zero, Quaternion.identity);
            a.transform.position = new Vector3(0, -2.45f, 0);
        } else if (animalType == AnimalType.Dog)
        {
            GameObject a = Instantiate(dogPrefab, Vector3.zero, Quaternion.identity);
            a.transform.position = new Vector3(0, -2.45f, 0);
        } else if (animalType == AnimalType.Mouse)
        {
            GameObject a = Instantiate(mousePrefab, Vector3.zero, Quaternion.identity);
            a.transform.position = new Vector3(0, -2.45f, 0);
        } else if (animalType == AnimalType.Cow)
        {
            GameObject a = Instantiate(cowPrefab, Vector3.zero, Quaternion.identity);
            a.transform.position = new Vector3(0, -2.45f, 0);
        } else if (animalType == AnimalType.Horse)
        {
            GameObject a = Instantiate(horsePrefab, Vector3.zero, Quaternion.identity);
            a.transform.position = new Vector3(0, -2.45f, 0);
        }
    }

    public void Start()
    {
        createTails();
    }

    void createTails()
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
            createTails();
        }
    }
}
