using System.Collections;
using System.Collections.Generic;
using Spine;
using Spine.Unity;
using UnityEngine;

public enum AnimalType
{
    Mouse,
    Horse,
    Dog,
    Pig,
    Cow,
    Cat
}

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
    [SerializeField]
    private string tapAnimationName;

    [SerializeField]
    private AnimalType type;

    [Header("Tails sprites")]
    [SerializeField]
    private SpriteRenderer catTail;
    [SerializeField]
    private SpriteRenderer cowTail;
    [SerializeField]
    private SpriteRenderer dogTail;
    [SerializeField]
    private SpriteRenderer horseTail;
    [SerializeField]
    private SpriteRenderer mouseTail;
    [SerializeField]
    private SpriteRenderer pigTail;

    public void Awake()
    {
        if (catTail != null)
        {
            catTail.gameObject.SetActive(false);
        }
        if (cowTail != null)
        {
            cowTail.gameObject.SetActive(false);
        }
        if (dogTail != null)
        {
            dogTail.gameObject.SetActive(false);
        }
        if (horseTail != null)
        {
            horseTail.gameObject.SetActive(false);
        }
        if (mouseTail != null)
        {
            mouseTail.gameObject.SetActive(false);
        }
        if (pigTail != null)
        {
            pigTail.gameObject.SetActive(false);
        }

        playIdle();
    }

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

    public void playTap()
    {
        StartCoroutine(playAnimationAndWait(tapAnimationName, idleAnimationName));
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
        if (setAnimal.type == type)
        {
            Slot tailSlot = getSlot();
            tailSlot.Attachment = setAnimal.getAttachment();
        } else if (setAnimal.type == AnimalType.Cat)
        {
            setTail(catTail);
        } else if (setAnimal.type == AnimalType.Cow)
        {
            setTail(cowTail);
        } else if (setAnimal.type == AnimalType.Dog)
        {
            setTail(dogTail);
        } else if (setAnimal.type == AnimalType.Horse)
        {
            setTail(horseTail);
        } else if (setAnimal.type == AnimalType.Mouse)
        {
            setTail(mouseTail);
        } else if (setAnimal.type == AnimalType.Pig)
        {
            setTail(pigTail);
        }
    }

    void setTail(SpriteRenderer tail)
    {
        StartCoroutine(setTailImpl(tail));
    }

    IEnumerator setTailImpl(SpriteRenderer tail)
    {
        tail.gameObject.SetActive(true);
        yield return new WaitForSeconds(0.7f);
        tail.gameObject.SetActive(false);
    }
}
