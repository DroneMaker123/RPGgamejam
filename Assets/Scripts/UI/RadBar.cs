using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadBar : MonoBehaviour
{
    public bool isPlayerOne = false;
    public Slider slider;
    public GameManager gameManager;

    public void SetRad(float health)
    {
        slider.value = 100.0f - health;
    }

    private void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void Update()
    {
        if (isPlayerOne)
        {
            SetRad(gameManager.getPlayer1HP());
        }
        else
        {
            SetRad(gameManager.getPlayer2HP());
        }
    }
}
