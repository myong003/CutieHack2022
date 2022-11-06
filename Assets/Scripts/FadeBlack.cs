using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeBlack : MonoBehaviour
{
    public GameObject endScreenLose;
    public GameObject endScreenWin;
    public Image blackScreenLose;
    public Image blackScreenWin;
    public float fadeSpeed;

    IEnumerator FadeToBlackLose() {
        while (blackScreenLose.color.a < 0.8f) {
            Color c = blackScreenLose.color;
            c.a += fadeSpeed;
            blackScreenLose.color = c;
            yield return null;
        }

        endScreenLose.SetActive(true);
    }
    
    IEnumerator FadeToBlackWin() {
        while (blackScreenWin.color.a < 0.8f) {
            Color c = blackScreenWin.color;
            c.a += fadeSpeed;
            blackScreenWin.color = c;
            yield return null;
        }

        endScreenWin.SetActive(true);
    }
}
