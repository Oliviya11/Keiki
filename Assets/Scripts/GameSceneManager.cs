using System.Collections;
using System.Collections.Generic;
using Spine;
using Spine.Unity;
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

    [Header("Animals skeleton data assets"), SerializeField]
    private SkeletonDataAsset pigData;
    [SerializeField]
    private SkeletonDataAsset catData;
    [SerializeField]
    private SkeletonDataAsset dogData;
    [SerializeField]
    private SkeletonDataAsset mouseData;
    [SerializeField]
    private SkeletonDataAsset cowData;
    [SerializeField]
    private SkeletonDataAsset horseData;

    [Header("Animals"), SerializeField]
    private GameObject pigAnimation;
    [SerializeField]
    private GameObject catAnimation;
    [SerializeField]
    private GameObject dogAnimation;
    [SerializeField]
    private GameObject mouseAnimation;
    [SerializeField]
    private GameObject cowAnimation;
    [SerializeField]
    private GameObject horseAnimation;

    [SerializeField]
    private GameObject animalPrefab;

    public void Awake()
    {
        createAnimal();
    }

    void createAnimal()
    {
        GameObject prefab;
        AnimalType animalType = GameManager.Instance.choosenAnimalType;
        GameObject animalGameObject = null;


        if (animalType == AnimalType.Pig)
        {

        }
        else if (animalType == AnimalType.Cat)
        {
            animalGameObject = Instantiate(catAnimation, Vector3.zero, Quaternion.identity);

        }
        else if (animalType == AnimalType.Dog)
        {
            animalGameObject = Instantiate(dogAnimation, Vector3.zero, Quaternion.identity);
        }
        else if (animalType == AnimalType.Mouse)
        {
            animalGameObject = Instantiate(mouseAnimation, Vector3.zero, Quaternion.identity);
        }
        else if (animalType == AnimalType.Cow)
        {
            animalGameObject = Instantiate(cowAnimation, Vector3.zero, Quaternion.identity);
        }
        else if (animalType == AnimalType.Horse)
        {
            animalGameObject = Instantiate(horseAnimation, Vector3.zero, Quaternion.identity);
        }

        Animal animal = animalGameObject.GetComponent<Animal>();
        GameManager.Instance.currentAnimal = animal;
        animalGameObject.transform.position = new Vector3(0, -2.45f, 0);
        animal.playIdle();

        GameManager.Instance.animations[AnimalType.Cat] = catAnimation.GetComponent<Animal>();
        GameManager.Instance.animations[AnimalType.Dog] = dogAnimation.GetComponent<Animal>();
        GameManager.Instance.animations[AnimalType.Mouse] = mouseAnimation.GetComponent<Animal>();
        GameManager.Instance.animations[AnimalType.Cow] = cowAnimation.GetComponent<Animal>();
        GameManager.Instance.animations[AnimalType.Horse] = horseAnimation.GetComponent<Animal>();
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
