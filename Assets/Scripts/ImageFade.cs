using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ImageFade : MonoBehaviour {
 
    // the image you want to fade, assign in inspector
    public Image img;
   
    public void StartFade()
    {
        // fades the image out when you click
        StartCoroutine(Halt());
    }

    private void Start()
    {
        StartFade();
    }

    IEnumerator Halt()
    {
        yield return new WaitForSeconds(5f);
        StartCoroutine(FadeImage(true));
    }

    IEnumerator FadeImage(bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
        // fade from transparent to opaque
        else
        {
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {

                img.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }
}