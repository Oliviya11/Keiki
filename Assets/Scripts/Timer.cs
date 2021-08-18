using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    float timeRemaining = 0;
    bool isTimerEnd = false;
    public Signal onTimerEnd = new Signal();

    public void reset(int time)
    {
        timeRemaining = time;
        isTimerEnd = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            //Debug.LogError(gameObject.name + " : " + timeRemaining);
        } else if (!isTimerEnd)
        {
            onTimerEnd.Invoke();
            isTimerEnd = true;
        }
    }
}
