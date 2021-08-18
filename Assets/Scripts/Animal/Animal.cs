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
    private string idleAnimationName = "Idle";
    [SerializeField]
    private string sadAnimationName;

    public string SadAnimationName
    {
        get
        {
            return sadAnimationName;
        }
    }

    public string IdleAnimationName
    {
        get
        {
            return idleAnimationName;
        }
    }

    public void playIdle()
    {
        skeletonAnimation.loop = true;
        skeletonAnimation.AnimationName = idleAnimationName;
        Slot tailSlot = getSlot();
        tailSlot.Attachment = null;
    }

    Slot getSlot()
    {
        return skeletonAnimation.Skeleton.FindSlot(tailSlotName);
    }

    public void playNo(string afterAnimation)
    {
        StartCoroutine(playAnimationAndWait(noAnimationName, afterAnimation));
    }

    public void playYes()
    {
        StartCoroutine(playAnimationAndWait(yesAnimationName, idleAnimationName));
    }

    IEnumerator playAnimationAndWait(string animationName, string afterAnimation)
    {
        skeletonAnimation.AnimationName = animationName;
        yield return new WaitForSeconds(1f);
        skeletonAnimation.AnimationName = afterAnimation;
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
