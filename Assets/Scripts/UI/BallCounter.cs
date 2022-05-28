using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class BallCounter : MonoBehaviour
{
    public bool isPlayerOne = false;
    public string number = "N";
    public Text text;
    public GameManager gameManager;

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (isPlayerOne)
        {
            text.text = Convert.ToString(gameManager.getPlayer1BallsLeft());
        }
        else
        {
            text.text = Convert.ToString(gameManager.getPlayer2BallsLeft());
        }
    }
}
