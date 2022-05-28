using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    CannonFiring cannonP1;
    [SerializeField]
    CannonFiring cannonP2;

    [SerializeField]
    float healthLose = 0.5f;

    player Player1 = new player(100, 5, 1); // Holds Player parameters
    player Player2 = new player(100, 5, 1); // health, ballsLeft, afterFireDelay

    int ballsHolderP1 = 0; //how many balls are affecting the Player
    int ballsHolderP2 = 0; 

    struct player
    {
        public float health;
        public int ballsLeft;
        public bool canFire;
        public float afterFireDelay;

        public player(float health, int ballsLeft, float afterFireDelay)
        {
            this.health = health;
            this.ballsLeft = ballsLeft;
            this.canFire = true;
            this.afterFireDelay = afterFireDelay;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        inputControls(); //Controls players inputs
        ballsCounter(); //Finds every balls through the map 
        loseHP();   //Players lose hp if are holding balls

    }

    void loseHP()
    { 
        Player1.health -= (Player1.ballsLeft + ballsHolderP1) * healthLose * Time.deltaTime;
        Player2.health -= (Player2.ballsLeft + ballsHolderP2) * healthLose * Time.deltaTime;

        //Edge cases
        if (Player1.health < 0) Player1.health = 0;
        if (Player2.health < 0) Player2.health = 0;
    }

    void inputControls() //different inputs for Player1 and Player2
    {

        if (Player1.ballsLeft > 0 && Input.GetKeyDown(KeyCode.Space) && Player1.canFire)
        {
            Player1.canFire = false;
            cannonP1.shoot();
            StartCoroutine(fireDelayP1(Player1.afterFireDelay));
            Player1.ballsLeft--;
        }

        if (Player2.ballsLeft > 0 && Input.GetKeyDown(KeyCode.KeypadEnter) && Player2.canFire)
        {
            Player2.canFire = false;
            cannonP2.shoot();
            StartCoroutine(fireDelayP2(Player2.afterFireDelay));
            Player2.ballsLeft--;
        }
    }

    void ballsCounter()
    {
        ballsHolderP1 = 0;
        ballsHolderP2 = 0;

        GameObject[] balls;
        balls = GameObject.FindGameObjectsWithTag("Projectile");

        foreach (GameObject ball in balls)
        {
            if(ball.transform.position.z > 19)
            {
                Player2.ballsLeft++;
                ballsHolderP2--;
                Destroy(ball);
            }
            else if(ball.transform.position.z < -19)
            {
                Player1.ballsLeft++;
                ballsHolderP1--;
                Destroy(ball);
            }
            else if(ball.transform.position.z > 0)
            {
                ballsHolderP2++;
            }
            else if (ball.transform.position.z < 0)
            {
                ballsHolderP1++;
            }
        }
    }

    IEnumerator fireDelayP1(float afterFireDelay)
    {
        yield return new WaitForSeconds(afterFireDelay);
        Player1.canFire = true;
    }

    IEnumerator fireDelayP2(float afterFireDelay)
    {
        yield return new WaitForSeconds(afterFireDelay);
        Player2.canFire = true;
    }


    public float getPlayer1HP()
    {
        return Player1.health;
    }

    public void setPlayer1HP(float hp)
    {
        Player1.health = hp;
    }
    
    public void setPlayer1BallsLeft(int balls)
    {
        Player1.ballsLeft = balls;
    }

    public float getPlayer2HP()
    {
        return Player2.health;
    }

    public void setPlayer2HP(float hp)
    {
        Player2.health = hp;
    }

    public void setPlayer2BallsLeft(int balls)
    {
        Player2.ballsLeft = balls;
    }

}
