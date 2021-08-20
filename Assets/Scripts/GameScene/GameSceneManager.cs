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
    private AnimalDataPrefab animalDataPrefab;

    [SerializeField]
    private AnimalCreator animalCreator;

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

    IEnumerator playSoundImpl()
    {
        yield return new WaitForSeconds(0.1f);

        playWhereIsMyTail();
    }

    void playWhereIsMyTail()
    {
        
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
        animalCreator.create(GameManager.Instance.choosenAnimalType);
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
