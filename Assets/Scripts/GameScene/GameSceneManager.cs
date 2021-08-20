using System;
using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSceneManager : MonoBehaviour
{
    private SceneLoader onceSceneLoader = new SceneLoader();

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

    [SerializeField]
    private AnimalDataPrefab animalDataPrefab;

    [SerializeField]
    private AnimalCreator animalCreator;

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
    private Button homeButton;

    [SerializeField]
    private Button animalButton;

    [Header("Timers")]
    [SerializeField]
    private Timer timer7s;
    [SerializeField]
    private Timer timer14s;

    public void Awake()
    {
        GameManager.Instance.gameSceneManager = this;
        createAnimal();
        homeButton.onClick.AddListener(onceSceneLoader.loadMenuScene);
        animalButton.onClick.AddListener(launchTapAnimation);
        GameManager.Instance.initWithTimers(timer7s, timer14s);
    }

    void launchTapAnimation()
    {
        GameManager.Instance.currentAnimal.playTap();
    }

    void playSound()
    {
        StartCoroutine(playSoundImpl());
    }

    IEnumerator playSoundImpl()
    {
        yield return new WaitForSeconds(0.1f);

        playWhereIsMyTail();
    }

    void playWhereIsMyTail()
    {
        AnimalType animalType = GameManager.Instance.choosenAnimalType;

        if (animalType == AnimalType.Pig)
        {
            SoundManager.playPigTailSound();
        }
        else if (animalType == AnimalType.Cat)
        {
            SoundManager.playCatTailSound();
        }
        else if (animalType == AnimalType.Dog)
        {
            SoundManager.playDogTailSound();
        }
        else if (animalType == AnimalType.Mouse)
        {
            SoundManager.playMouseTailSound();
        }
        else if (animalType == AnimalType.Cow)
        {
            SoundManager.playCowTailSound();
        }
        else if (animalType == AnimalType.Horse)
        {
            SoundManager.playHorseTailSound();
        }
    }

    public void playSoundAndAction(Action action)
    {
        StartCoroutine(playSoundAndActionImpl(action));
    }

    IEnumerator playSoundAndActionImpl(Action action)
    {
        playWhereIsMyTail();
        yield return new WaitForSeconds(1);
        action();
    }

    void createAnimal()
    {
        playSound();
        animalCreator.create(GameManager.Instance.choosenAnimalType);
    }

    public void Start()
    {
        //createTails();
    }

    void createTails()
    {
        clearTails();
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
            if (GameManager.Instance.choosenAnimalType == animalTail.animalType)
            {
                GameManager.Instance.rightAnimalTail = animalTail;
            }
            tailTransform.anchoredPosition = Vector2.zero;

            GameManager.Instance.pulsingTails.Add(tail.GetComponent <Pulsing>());

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

        currentSafeArea = safeArea;
        currentOrientation = Screen.orientation;
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
            //createTails();
        }
    }

    public void waitAndloadMenuScene()
    {
        StartCoroutine(waitAndloadMenuSceneImpl());
    }

    IEnumerator waitAndloadMenuSceneImpl ()
    {
        yield return new WaitForSeconds(2f);
        onceSceneLoader.loadMenuScene();
    }
}
