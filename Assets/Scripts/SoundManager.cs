using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    static List<AudioClip> casounds = new List<AudioClip>(),
        iasounds = new List<AudioClip>();

    AudioSource audioSource;

    [SerializeField]
    private AnimalDataPrefab animalDataPrefab;

    static SoundManager instance;

    public static SoundManager Instance
    {
        get
        {
            return instance;
        }
    }

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        if (instance == null)
        {
            instance = this;
        }

        //casounds.Add(Resources.Load<AudioClip>("MOTHER_CA_01"));
        //casounds.Add(Resources.Load<AudioClip>("MOTHER_CA_02"));
        //casounds.Add(Resources.Load<AudioClip>("MOTHER_CA_03"));
        //casounds.Add(Resources.Load<AudioClip>("MOTHER_CA_04"));
        //casounds.Add(Resources.Load<AudioClip>("MOTHER_CA_05"));
        //casounds.Add(Resources.Load<AudioClip>("MOTHER_CA_06"));
        //casounds.Add(Resources.Load<AudioClip>("MOTHER_CA_07"));

        //iasounds.Add(Resources.Load<AudioClip>("MOTHER_IA_01"));
        //iasounds.Add(Resources.Load<AudioClip>("MOTHER_IA_02"));
        //iasounds.Add(Resources.Load<AudioClip>("MOTHER_IA_03"));
        //iasounds.Add(Resources.Load<AudioClip>("MOTHER_IA_04"));
        //iasounds.Add(Resources.Load<AudioClip>("MOTHER_IA_05"));
        //iasounds.Add(Resources.Load<AudioClip>("MOTHER_IA_06"));
        //iasounds.Add(Resources.Load<AudioClip>("MOTHER_IA_07"));
    }

    //public static void playCASound()
    //{
    //    playSound(getCAIASound(casounds));
    //}

    //public static void playIASound()
    //{
    //    playSound(getCAIASound(iasounds));
    //}

    //static AudioClip getCAIASound(List<AudioClip> l)
    //{
    //    int randomNumber = Random.Range(0, l.Count);
    //    return l[randomNumber];
    //}

    void playSound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }

    public void playAnimalSound(AnimalType animalType)
    {
        AnimalIconData animalData = animalDataPrefab.getAnimalData(animalType);
        playSound(animalData.WhereIsMyTailClip);
    }
}
