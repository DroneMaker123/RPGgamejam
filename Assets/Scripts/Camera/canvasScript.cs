using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class canvasScript : MonoBehaviour
{
    [SerializeField]
    Text IntroText;
    [SerializeField]
    Image IntroTextIm;
    [SerializeField]
    Text Controls1Text, Controls2Text;
    [SerializeField]
    Image Controls1TextIm, Controls2TextIm;
    [SerializeField]
    Text PressStart;
    [SerializeField]
    Image WhiteScreen;

    int titleScreenStates = 0;

    int sign = 1;

    void Start()
    {
        Color clearAlpha = IntroText.color;
        clearAlpha.a = 0;
        IntroText.color = clearAlpha;
        clearAlpha = IntroTextIm.color;
        clearAlpha.a = 0;
        IntroTextIm.color = clearAlpha;
        clearAlpha = Controls1Text.color;
        clearAlpha.a = 0;
        Controls1Text.color = clearAlpha;
        clearAlpha = Controls1TextIm.color;
        clearAlpha.a = 0;
        Controls1TextIm.color = clearAlpha;
        clearAlpha = Controls2Text.color;
        clearAlpha.a = 0;
        Controls2Text.color = clearAlpha;
        clearAlpha = Controls2TextIm.color;
        clearAlpha.a = 0;
        Controls2TextIm.color = clearAlpha;
        clearAlpha = PressStart.color;
        clearAlpha.a = 0;
        PressStart.color = clearAlpha;
    }

    // Update is called once per frame
    void Update()
    {
        switch (titleScreenStates)
        {
            case 0:
                {
                    Color alpha = WhiteScreen.color;
                    alpha.a -= Time.deltaTime;
                    if (alpha.a <= 0)
                    {
                        alpha.a = 0;
                        titleScreenStates++;
                    }
                    WhiteScreen.color = alpha;
                    break;
                }
            case 1:
                {
                    titleScreenStates++;
                    StartCoroutine(delayState(0.5f));
                    break;
                }
            case 3:
                {
                    Color alpha = IntroText.color;
                    alpha.a += Time.deltaTime;
                    if(alpha.a >= 1)
                    {
                        alpha.a = 1;
                        titleScreenStates++;
                    }
                    IntroText.color = alpha;
                    IntroTextIm.color = alpha;
                    break;
                }
            case 4:
                {
                    titleScreenStates++;
                    StartCoroutine(delayState(1.0f));
                    break;
                }
            case 6:
                {
                    Color alpha = Controls1Text.color;
                    alpha.a += Time.deltaTime;
                    if (alpha.a >= 1)
                    {
                        alpha.a = 1;
                        titleScreenStates++;
                    }
                    Controls1Text.color = alpha;
                    Controls1TextIm.color = alpha;
                    Controls2Text.color = alpha;
                    Controls2TextIm.color = alpha;
                    break;
                }
            case 7:
                {
                    Color alpha = PressStart.color;
                    alpha.a += Time.deltaTime*sign;
                    if (alpha.a >= 1 || alpha.a <= 0)
                    {
                        sign = -sign;
                    }
                    PressStart.color = alpha;
                    if(Input.GetKey(KeyCode.Space) || Input.GetKey(KeyCode.KeypadEnter) || Input.GetKey(KeyCode.Return))
                    {
                        titleScreenStates++;
                    }
                    break;
                }
            case 8:
                {
                    Color alpha = WhiteScreen.color;
                    alpha.a += Time.deltaTime;
                    if (alpha.a >= 1)
                    {
                        alpha.a = 1;
                        WhiteScreen.color = alpha;
                        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

                    }
                    WhiteScreen.color = alpha;
                    break;
                }
        }

        
    }

    void nextState()
    {
        
    }
    IEnumerator delayState(float delay)
    {
        yield return new WaitForSeconds(delay);
        titleScreenStates++;
    }
}

    
