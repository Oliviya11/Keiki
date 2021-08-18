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
}
