using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField]
    Text StartText;
    [SerializeField]
    Image Background;
    [SerializeField]
    Image Logo;
    [SerializeField]
    Text LevelsSelect, Levels;
    [SerializeField]
    Text Credits, CreditsAll;
    [SerializeField]
    Text Exit;
    [SerializeField]
    Image BlackScreen;

    float timePassed = 0.0f;

    int menuState = 0;

    bool levelSelected = false;


    // Start is called before the first frame update
    void Start()
    {
        Levels.enabled = false;
        CreditsAll.enabled = false;
        StartText.fontSize = 34;
    }

    // Update is called once per frame
    void Update()
    {
        timePassed += Time.deltaTime;

        switch(menuState)
        {
            case 0:
                {
                    Color alpha = BlackScreen.color;
                    alpha.a -= Time.deltaTime;
                    if (alpha.a <= 0)
                    {
                        alpha.a = 0;
                        menuState++;
                    }
                    BlackScreen.color = alpha;
                    break;
                }
            case 1:
                {
                    StartText.fontSize = 34;
                    Vector3 rot = StartText.transform.eulerAngles;
                    rot.z += Mathf.Sin(timePassed)/80;
                    StartText.transform.eulerAngles = rot;
                    
                    if(Input.GetKeyDown(KeyCode.Space))
                    {
                        FindObjectOfType<AudioManager>().Play("UI_Sound");
                        if (levelSelected) SceneManager.LoadScene(3);
                        else SceneManager.LoadScene(1);
                    }

                    else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        FindObjectOfType<AudioManager>().Play("UI_Sound");
                        rot.z = 0;
                        StartText.transform.eulerAngles = rot;
                        StartText.fontSize = 28;
                        menuState++;
                    }


                    break;
                }
            case 2:
                {
                    LevelsSelect.fontSize = 34;
                    Vector3 rot = LevelsSelect.transform.eulerAngles;
                    rot.z += Mathf.Sin(timePassed) / 80;
                    LevelsSelect.transform.eulerAngles = rot;
                    

                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        FindObjectOfType<AudioManager>().Play("UI_Sound");
                        menuState = 12;
                    }

                    else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        FindObjectOfType<AudioManager>().Play("UI_Sound");
                        rot.z = 0;
                        LevelsSelect.transform.eulerAngles = rot;
                        LevelsSelect.fontSize = 28;
                        menuState++;
                    }

                    else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        FindObjectOfType<AudioManager>().Play("UI_Sound");
                        rot.z = 0;
                        LevelsSelect.transform.eulerAngles = rot;
                        LevelsSelect.fontSize = 28;
                        menuState--;
                    }

                    break;
                }
            case 3:
                {
                    Credits.fontSize = 34;
                    Vector3 rot = Credits.transform.eulerAngles;
                    rot.z += Mathf.Sin(timePassed) / 80;
                    Credits.transform.eulerAngles = rot;


                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        FindObjectOfType<AudioManager>().Play("UI_Sound");
                        menuState = 13;
                    }

                    else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                    {
                        FindObjectOfType<AudioManager>().Play("UI_Sound");
                        rot.z = 0;
                        Credits.transform.eulerAngles = rot;
                        Credits.fontSize = 28;
                        menuState++;
                    }

                    else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        FindObjectOfType<AudioManager>().Play("UI_Sound");
                        rot.z = 0;
                        Credits.transform.eulerAngles = rot;
                        Credits.fontSize = 28;
                        menuState--;
                    }

                    break;
                }
            case 4:
                {
                    Exit.fontSize = 34;
                    Vector3 rot = Exit.transform.eulerAngles;
                    rot.z += Mathf.Sin(timePassed) / 80;
                    Exit.transform.eulerAngles = rot;


                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        FindObjectOfType<AudioManager>().Play("UI_Sound");
                        Application.Quit();
                    }

                    else if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                    {
                        FindObjectOfType<AudioManager>().Play("UI_Sound");
                        rot.z = 0;
                        Exit.transform.eulerAngles = rot;
                        Exit.fontSize = 28;
                        menuState--;
                    }

                    break;
                }

            case 12:
                {
                    StartText.enabled = false;
                    Credits.enabled = false;
                    Exit.enabled = false;

                    Vector3 rot = LevelsSelect.transform.eulerAngles;
                    rot.z += Mathf.Sin(timePassed) / 80;
                    LevelsSelect.transform.eulerAngles = rot;

                    Levels.enabled = true;

                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        FindObjectOfType<AudioManager>().Play("UI_Sound");
                        StartText.enabled = true;
                        Credits.enabled = true;
                        Exit.enabled = true;

                        Levels.enabled = false;

                        menuState = 2;
                    }
                    else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
                    {
                        FindObjectOfType<AudioManager>().Play("UI_Sound");
                        if (levelSelected)
                        {
                            levelSelected = false;
                            Levels.text = "< Level 01 >";
                        }
                        else
                        {
                            levelSelected = true;
                            Levels.text = "< Level 02 >";
                        }
                    }
                    break;
                }
            case 13:
                {
                    Vector3 rot = Credits.transform.eulerAngles;
                    rot.z += Mathf.Sin(timePassed) / 80;
                    Credits.transform.eulerAngles = rot;

                    StartText.enabled = false;
                    LevelsSelect.enabled = false;
                    Exit.enabled = false;

                    CreditsAll.enabled = true;

                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        FindObjectOfType<AudioManager>().Play("UI_Sound");
                        StartText.enabled = true;
                        LevelsSelect.enabled = true;
                        Exit.enabled = true;

                        CreditsAll.enabled = false;

                        menuState = 3;
                    }

                    break;
                }
        }
    }
}
