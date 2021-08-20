using UnityEngine;

[CreateAssetMenu(fileName = "New AnimalIconData", menuName = "AnimalIcon Data", order = 51)]
public class AnimalIconData: ScriptableObject
{
    [SerializeField]
    private AnimalType animalType;

    [SerializeField]
    private Sprite animalIcon;

    [SerializeField]
    private Sprite tailSprite;

    [SerializeField]
    private GameObject animalAnimation;

    [SerializeField]
    private AudioClip whereIsMyTailClip;

    public Sprite AnimalIcon
    {
        get
        {
            return animalIcon;
        }
    }

    public Sprite TailSprite
    {
        get
        {
            return tailSprite;
        }
    }

    public AnimalType AnimalType
    {
        get
        {
            return animalType;
        }
    }

    public GameObject AnimalAnimation
    {
        get
        {
            return animalAnimation;
        }
    }

    public AudioClip WhereIsMyTailClip
    {
        get
        {
            return whereIsMyTailClip;
        }
    }
}
