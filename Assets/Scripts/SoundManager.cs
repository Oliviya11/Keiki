using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip catTailSound;
    public static AudioClip cowTailSound;
    public static AudioClip dogTailSound;
    public static AudioClip horseTailSound;
    public static AudioClip mouseTailSound;
    public static AudioClip pigTailSound;

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
