using System;
using System.Collections.Generic;
using Spine.Unity;

public enum AnimalType
{
    Mouse,
    Horse,
    Dog,
    Pig,
    Cow,
    Cat
}
public class GameManager
{
    private static GameManager instance;

    public AnimalType choosenAnimalType;

    public Animal currentAnimal;

    public GameSceneManager gameSceneManager;

    public readonly Dictionary<AnimalType, Animal> animations =
        new Dictionary<AnimalType, Animal>();

    private GameManager()
    {
    }

    public static GameManager Instance {
        get
        {
            if (instance == null)
                instance = new GameManager();
            return instance;
        }
    }


    public void onAnimalTailChoosen(AnimalType tailType)
    {
        currentAnimal.setTail(animations[tailType]);
        if (tailType != choosenAnimalType)
        {
            currentAnimal.playNo();
            SoundManager.playIASound();
        }
        else
        {
            currentAnimal.playYes();
            SoundManager.playCASound();
            gameSceneManager.waitAndloadMenuScene();
        }
    }
}
