﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinSplash : MonoBehaviour
{
    public Vector3 minScale;
    public Vector3 maxScale;
    public bool repeatFlag;
    public float scalingSpeed;
    public float scalingDuration;
    private bool isAnimating = false;

    //public GameObject thisSplash;

    void Start()
    {
        transform.localScale = minScale;
    }

    public void Splash()
    {
        gameObject.SetActive(true);
        if (!isAnimating) // Check if animation is not already in progress.
        {
            StartCoroutine(PlaySplash());
        }
    }

    public IEnumerator PlaySplash()
    {
        isAnimating = true; // Set the animation flag to true.

        // Scale up animation
        yield return RepeatLerping(minScale, maxScale, scalingDuration);

        // Wait for a moment (optional delay)
        yield return new WaitForSeconds(1.0f);

        // Scale down animation
        yield return RepeatLerping(maxScale, minScale, scalingDuration);

        // Animation is complete, set the flag to false.
        isAnimating = false;

        // Optionally, disable the GameObject.
        gameObject.SetActive(false);
    }
    //public IEnumerator PlaySplash()
    //{
    //    //gameObject.SetActive(true);
    //    isAnimating = true;

    //    while (repeatFlag)
    //    {
    //        yield return RepeatLerping(minScale, maxScale, scalingDuration);

    //        // Wait for the scaling up animation to finish before proceeding
    //        while (transform.localScale != maxScale)
    //        {
    //            yield return null;
    //        }

    //        yield return RepeatLerping(maxScale, minScale, scalingDuration);

    //        // Wait for the scaling down animation to finish before proceeding
    //        while (transform.localScale != minScale)
    //        {
    //            yield return null;
    //        }
    //    }
    //}

    public void DisableSplash()
    {
        //gameObject.SetActive(false);
    }

    IEnumerator RepeatLerping(Vector3 startScale, Vector3 endScale, float time)
    {
        float t = 0.0f;
        float rate = (1f / time) * scalingSpeed;
        while (t < 1f)
        {
            t += Time.deltaTime * rate;
            transform.localScale = Vector3.Lerp(startScale, endScale, t);
            yield return null;
        }
    }
}
