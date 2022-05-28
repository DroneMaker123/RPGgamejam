using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerWinText : MonoBehaviour
{
    public UI UI;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (UI.isPlayerOneWin)
        {
            text.text = "Player One Wins!";
        }
        else if (UI.isPlayerTwoWin)
        {
            text.text = "Player Two Wins!";
        }
    }
}
