using System;
using System.Collections.Generic;
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
public class GameManager
{
    private static GameManager instance;

    public AnimalType choosenAnimalType;

    public Animal currentAnimal;

    public AnimalTail rightAnimalTail;

    public GameSceneManager gameSceneManager;

    public readonly Dictionary<AnimalType, Animal> animations =
        new Dictionary<AnimalType, Animal>();

    public readonly List<Pulsing> pulsingTails = new List<Pulsing>();

    private int incorrectChoicesCounter = 0;

    private bool isPulsing = false;

    private Timer timer7s, timer14s;

    enum TimerState
    {
        None,
        Timer7s,
        Timer14s
    }

    TimerState timerState = TimerState.None;

    public void initWithTimers(Timer t7s, Timer t14s)
    {
        timer7s = t7s;
        timer14s = t14s;
        resetTimers();
        connectTimerSignals();
    }

    void connectTimerSignals()
    {
        timer7s.onTimerEnd.AddListener(onTimer7sEnd);
        timer14s.onTimerEnd.AddListener(onTimer14sEnd);
    }

    void onTimer7sEnd()
    {
        timerState = TimerState.Timer7s;
        playSoundAndStartPulse();
    }

    void onTimer14sEnd()
    {
        timerState = TimerState.Timer14s;
        playSoundAndStartPulse();
    }

    void playSoundAndStartPulse()
    {
        gameSceneManager.playSoundAndAction(pulseTails);
    }

    void resetTimers()
    {
        stopPulseTails();
        if (timerState == TimerState.Timer14s)
        {
            rightAnimalTail.setHand(false);
        }
        timerState = TimerState.None;
        timer7s.reset(7);
        timer14s.reset(14);
    }

    public void reset()
    {
        incorrectChoicesCounter = 0;
    }

    private GameManager()
    {
    }

    public void pulseTails()
    {
        if (!isPulsing)
        {
            isPulsing = true;
            for (int i = 0; i < pulsingTails.Count; ++i)
            {
                pulsingTails[i].pulse();
            }
        }

        if (timerState == TimerState.Timer14s)
        {
            rightAnimalTail.setHand(true);
        }
    }

    public void stopPulseTails()
    {
        if (isPulsing)
        {
            isPulsing = false;
            for (int i = 0; i < pulsingTails.Count; ++i)
            {
                pulsingTails[i].stopPulsing();
            }
        }
    }

    public static GameManager Instance {
        get
        {
            if (instance == null)
                instance = new GameManager();
            return instance;
        }
    }


    public void onAnimalTailChoosen(AnimalType tailType)
    {
        currentAnimal.setTail(animations[tailType]);
        bool isCorrectChoice = tailType == choosenAnimalType;
        if (!isCorrectChoice)
        {
            incorrectChoicesCounter++;

            if (incorrectChoicesCounter <= 2)
            {
                currentAnimal.playNo(currentAnimal.IdleAnimationName);
            } else
            {
                currentAnimal.playNo(currentAnimal.SadAnimationName);
            }
            
            SoundManager.playIASound();
        }
        else
        {
            currentAnimal.playYes();
            SoundManager.playCASound();
            gameSceneManager.waitAndloadMenuScene();
        }

        bool isBeforeTimer14 = timerState == TimerState.Timer7s || timerState == TimerState.None;
        bool isTimer14Reset = timerState == TimerState.Timer14s && isCorrectChoice;

        if (isBeforeTimer14 || isTimer14Reset)
        {
            resetTimers();
        }
    }
}
