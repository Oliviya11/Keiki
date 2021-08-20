using UnityEngine;
using static Dics;

public class AnimalDataPrefab : MonoBehaviour
{
    public AnimalTypeDataDictionary animalTypeDataDictionary;

    public AnimalIconData getAnimalData(AnimalType animalType)
    {
        AnimalIconData data;
        animalTypeDataDictionary.TryGetValue(animalType, out data);
        return data;
    }
}
