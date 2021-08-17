using System;
using UnityEngine;

[CreateAssetMenu(fileName = "New AnimalTailData", menuName = "AnimalTail Data", order = 52)]
public class AnimalTailData : ScriptableObject
{
    [SerializeField]
    private Sprite tailSprite;

    public Sprite TailSprite
    {
        get
        {
            return tailSprite;
        }
    }
}
