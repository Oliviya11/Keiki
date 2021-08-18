using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pulsing : MonoBehaviour
{
    private bool coroutineAllowed = true;

    public bool isInfinite = false;
    //void Start()
    //{
    //    if (isInfinite)
    //    {
    //        pulse();
    //    }
    //}

    public void pulse()
    {
        StartCoroutine(startPulsing());
    }

    public void pulseInfinite()
    {
        isInfinite = true;
        StartCoroutine(startPulsing());
    }

    private IEnumerator startPulsing()
    {
        if (coroutineAllowed)
        {
            coroutineAllowed = false;

            for (float i = 0f; i <= 1f; i += 0.1f)
            {
                transform.localScale = new Vector3(
                    (Mathf.Lerp(transform.localScale.x, transform.localScale.x + 0.025f,
                        Mathf.SmoothStep(0f, 1f, i))),
                    (Mathf.Lerp(transform.localScale.y, transform.localScale.y + 0.025f,
                        Mathf.SmoothStep(0f, 1f, i))),
                    (Mathf.Lerp(transform.localScale.z, transform.localScale.z + 0.025f,
                        Mathf.SmoothStep(0f, 1f, i)))
                );

                yield return new WaitForSeconds(0.05f);
            }

            for (float i = 0f; i <= 1f; i += 0.1f)
            {
                transform.localScale = new Vector3(
                    (Mathf.Lerp(transform.localScale.x, transform.localScale.x - 0.025f,
                        Mathf.SmoothStep(0f, 1f, i))),
                    (Mathf.Lerp(transform.localScale.y, transform.localScale.y - 0.025f,
                        Mathf.SmoothStep(0f, 1f, i))),
                    (Mathf.Lerp(transform.localScale.z, transform.localScale.z - 0.025f,
                        Mathf.SmoothStep(0f, 1f, i)))
                );

                yield return new WaitForSeconds(0.05f);
            }
        }

        coroutineAllowed = true;
        if (isInfinite)
        {
            yield return StartCoroutine(startPulsing());
        }
    }

    public void stopPulsing()
    {
        StopAllCoroutines();
    }
}
