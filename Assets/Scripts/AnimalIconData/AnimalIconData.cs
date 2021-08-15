using UnityEngine;

[CreateAssetMenu(fileName = "New AnimalIconData", menuName = "AnimalIcon Data", order = 51)]
public class AnimalIconData: ScriptableObject
{
    [SerializeField]
    private Sprite animalIcon;

    public Sprite AnimalIcon
    {
        get
        {
            return animalIcon;
        }
    }
}
