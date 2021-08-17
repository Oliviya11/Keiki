using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LaunchSceneManager : MonoBehaviour
{
    [SerializeField]
    private GameObject iconButtonPrefab;
    [SerializeField]
    private List<AnimalIconData> animalIconData;
    [SerializeField]
    Canvas canvas;

    private const int ANIMALS_ICONS_NUMBER = 6;
    private const int X_DELTA = -410;
    private const int Y_DELTA = 215;

    public void Awake()
    {
        int x = X_DELTA;
        int y = Y_DELTA;

        for (int i = 0; i < ANIMALS_ICONS_NUMBER; ++i)
        {
            GameObject btn = Instantiate(iconButtonPrefab, Vector3.zero, Quaternion.identity, canvas.transform);
            btn.transform.localPosition = new Vector3(x, y, 0);
            IconButton iconBtn = btn.GetComponent<IconButton>();
            iconBtn.setData(animalIconData[i]);
            Button btnComp = btn.GetComponent<Button>();
            int k = i;
            btnComp.onClick.AddListener(delegate
            {
                onButtonClick(animalIconData[k].AnimalType);
            });
            x -= X_DELTA;
            if (i == 2)
            {
                x = X_DELTA;
                y -= 2 * Y_DELTA;
            }
        }
    }

    public void onButtonClick(AnimalType animal)
    {
        GameManager.Instance.choosenAnimal = animal;
        //Debug.LogError(animal);
        SceneManager.LoadScene("Game");
    }
}
