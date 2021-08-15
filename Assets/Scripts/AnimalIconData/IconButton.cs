using System;
using UnityEngine;
using UnityEngine.UI;

public class IconButton : MonoBehaviour
{
    [SerializeField]
    private Image sprite;

    public void setData(AnimalIconData _data)
    {
        sprite.sprite = _data.AnimalIcon;
    }
}
