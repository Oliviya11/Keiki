using System;
using UnityEngine;

public class AnimalCreator : MonoBehaviour
{
    public GameObject animalPrefab;
    public Vector2 position;

    public void create()
    {
        GameObject animalGameObject = Instantiate(animalPrefab, Vector3.zero, Quaternion.identity);
        animalGameObject.transform.position = position;
    }
}
