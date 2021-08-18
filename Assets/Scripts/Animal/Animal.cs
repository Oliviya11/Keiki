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
    [SerializeField]
    private string noAnimationName;
    [SerializeField]
    private string yesAnimationName;
    private string idle = "Idle";

    public void playIdle()
    {
        skeletonAnimation.loop = true;
        skeletonAnimation.AnimationName = idle;
        Slot tailSlot = getSlot();
        tailSlot.Attachment = null;
    }

    Slot getSlot()
    {
        return skeletonAnimation.Skeleton.FindSlot(tailSlotName);
    }

    public void playNo()
    {
        StartCoroutine(playAnimationAndWait(noAnimationName));
    }

    public void playYes()
    {
        StartCoroutine(playAnimationAndWait(yesAnimationName));
    }

    IEnumerator playAnimationAndWait(string animationName)
    {
        skeletonAnimation.AnimationName = animationName;
        yield return new WaitForSeconds(1f);
        skeletonAnimation.AnimationName = idle;
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
