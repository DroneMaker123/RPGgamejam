using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallParameters : MonoBehaviour
{
    bool player2 = false;

    public void setPlayer2() //Set that it was fired by Player2
    {
        player2 = true;
    }

    public bool getPlayer2() //Check if it was fired by Player2
    {
        return player2;
    }
}
