using System;
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

    public AnimalType choosenAnimal;

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
