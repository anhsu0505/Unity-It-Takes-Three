using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public Image faderImg;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        faderImg.gameObject.SetActive(true);
        faderImg.canvasRenderer.SetAlpha(1);
        faderImg.CrossFadeAlpha(0,2f,true);//fade to, time, if ignore time scale
        yield return new WaitForSeconds(2f);//wait fading
        faderImg.gameObject.SetActive(false);//disappear when fading finishes

    }
}
