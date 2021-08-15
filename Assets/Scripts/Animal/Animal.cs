using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField]
    private SkeletonAnimation skeletonAnimation;
    void Awake()
    {
        skeletonAnimation.loop = true;
        skeletonAnimation.AnimationName = "Walk";
    }
}
