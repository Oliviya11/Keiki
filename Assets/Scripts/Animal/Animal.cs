using System.Collections;
using System.Collections.Generic;
using Spine;
using Spine.Unity;
using UnityEngine;

public class Animal : MonoBehaviour
{
    public SkeletonAnimation skeletonAnimation;
    [SerializeField]
    private string tailSlotName;
    private Attachment tailAttachment;

    public void playIdle()
    {
        skeletonAnimation.loop = true;
        skeletonAnimation.AnimationName = "Idle";
        Slot tailSlot = getSlot();
        tailSlot.Attachment = null;
    }

    Slot getSlot()
    {
        return skeletonAnimation.Skeleton.FindSlot(tailSlotName);
    }

    public Attachment getAttachment()
    {
        return getSlot().Attachment;
    }

    public void setTail(Animal setAnimal)
    {
        Slot tailSlot = getSlot();
        tailSlot.Attachment = setAnimal.getAttachment();
    }
}
