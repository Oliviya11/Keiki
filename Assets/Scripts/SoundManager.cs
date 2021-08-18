using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip catTailSound;
    public static AudioClip cowTailSound;
    public static AudioClip dogTailSound;
    public static AudioClip horseTailSound;
    public static AudioClip mouseTailSound;
    public static AudioClip pigTailSound;

    static List<AudioClip> casounds = new List<AudioClip>(),
        iasounds = new List<AudioClip>();

    static AudioSource audioSource;

    private void Awake()
    {
        catTailSound = Resources.Load<AudioClip>("CAT_09");
        cowTailSound = Resources.Load<AudioClip>("COW_09");
        dogTailSound = Resources.Load<AudioClip>("DOG_09");
        horseTailSound = Resources.Load<AudioClip>("HORSE_09");
        mouseTailSound = Resources.Load<AudioClip>("MOUSE_09");
        pigTailSound = Resources.Load<AudioClip>("PIG_09");
        audioSource = GetComponent<AudioSource>();

        casounds.Add(Resources.Load<AudioClip>("MOTHER_CA_01"));
        casounds.Add(Resources.Load<AudioClip>("MOTHER_CA_02"));
        casounds.Add(Resources.Load<AudioClip>("MOTHER_CA_03"));
        casounds.Add(Resources.Load<AudioClip>("MOTHER_CA_04"));
        casounds.Add(Resources.Load<AudioClip>("MOTHER_CA_05"));
        casounds.Add(Resources.Load<AudioClip>("MOTHER_CA_06"));
        casounds.Add(Resources.Load<AudioClip>("MOTHER_CA_07"));

        iasounds.Add(Resources.Load<AudioClip>("MOTHER_IA_01"));
        iasounds.Add(Resources.Load<AudioClip>("MOTHER_IA_02"));
        iasounds.Add(Resources.Load<AudioClip>("MOTHER_IA_03"));
        iasounds.Add(Resources.Load<AudioClip>("MOTHER_IA_04"));
        iasounds.Add(Resources.Load<AudioClip>("MOTHER_IA_05"));
        iasounds.Add(Resources.Load<AudioClip>("MOTHER_IA_06"));
        iasounds.Add(Resources.Load<AudioClip>("MOTHER_IA_07"));
    }

    public static void playCASound()
    {
        playSound(getCAIASound(casounds));
    }

    public static void playIASound()
    {
        playSound(getCAIASound(iasounds));
    }

    static AudioClip getCAIASound(List<AudioClip> l)
    {
        int randomNumber = Random.Range(0, l.Count);
        return l[randomNumber];
    }

    public static void playCatTailSound()
    {
        playSound(catTailSound);
    }

    public static void playCowTailSound()
    {
        playSound(cowTailSound);
    }

    public static void playDogTailSound()
    {
        playSound(dogTailSound);
    }

    public static void playHorseTailSound()
    {
        playSound(horseTailSound);
    }

    public static void playMouseTailSound()
    {
        playSound(mouseTailSound);
    }

    public static void playPigTailSound()
    {
        playSound(pigTailSound);
    }

    static void playSound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
