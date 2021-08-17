using System.Collections;
using System.Collections.Generic;
using Spine.Unity;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField]
    private SkeletonAnimation skeletonAnimation;
    [SerializeField]
    private string tailSlotName;

    void Awake()
    {
        skeletonAnimation.loop = true;
        skeletonAnimation.AnimationName = "Idle";
        var slot = skeletonAnimation.Skeleton.FindSlot(tailSlotName);
        slot.Attachment = null;
    }
}
