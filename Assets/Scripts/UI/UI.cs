using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    public Button reset;
    public Button exit;
    public Button menu;

    public bool isGameOver = false;
    public bool isPlayerOneWin = false;
    public bool isPlayerTwoWin = false;

    public GameManager gameManager;

    public Canvas winscreen;


    // Start is called before the first frame update
    void Start()
    {
        menu.onClick.AddListener(MenuClicked);
        reset.onClick.AddListener(ResetClicked);
        exit.onClick.AddListener(ExitClicked);

        gameManager = FindObjectOfType<GameManager>();

        winscreen.enabled = false;
    }

    void MenuClicked()
    {
        FindObjectOfType<AudioManager>().Play("UI_Sound");
        SceneManager.LoadScene("Menu");
    }

    void ResetClicked()
    {
        FindObjectOfType<AudioManager>().Play("UI_Sound");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void ExitClicked()
    {
        FindObjectOfType<AudioManager>().Play("UI_Sound");
        Application.Quit();
    }

    // Update is called once per frame
    void Update()
    {

        if (!isGameOver)
        {
            winscreen.enabled = false;
            if (gameManager.getPlayer1HP() <= 0)
            {
                isGameOver = true;
                isPlayerTwoWin = true;
            }
            else if (gameManager.getPlayer2HP() <= 0)
            {
                isGameOver = true;
                isPlayerOneWin = true;
            }
        }
        else
        {
            winscreen.enabled = true;
        }
    }
}
