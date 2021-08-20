using System;
using UnityEngine;

public class AnimalCreator : MonoBehaviour
{
    [SerializeField]
    private AnimalDataPrefab animalsPrefab;

    public void create(AnimalType animalType)
    {
        AnimalIconData data = animalsPrefab.getAnimalData(animalType);
        if (data != null)
        {
            GameObject animalGameObject = Instantiate(data.AnimalAnimation, Vector3.zero, Quaternion.identity);
            animalGameObject.transform.position = new Vector3(0, -3f, 0);
            Animal animal = animalGameObject.GetComponent<Animal>();
            GameManager.Instance.currentAnimal = animal;
        }
    }
}
