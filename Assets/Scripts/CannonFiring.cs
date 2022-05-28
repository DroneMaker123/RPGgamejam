using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonFiring : MonoBehaviour
{ 
    [SerializeField]
    bool player2 = false;

    [SerializeField]
    Transform firePoint;

    [SerializeField]
    GameObject shootingBallPrefab;

    [SerializeField]
    float afterFiringDelay = 1.0f;


    private bool canFire = true;

    private void Update()
    {
        inputControls();
    }

    IEnumerator fireDelay() 
    {
        yield return new WaitForSeconds(afterFiringDelay);
        canFire = true;
    }

    void inputControls() //different inputs for Player1 and Player2
    {
        if (!player2)
        {
            if (canFire && Input.GetKey(KeyCode.Space))
            {
                shoot();
                canFire = false;
                StartCoroutine(fireDelay());
            }
        }
        else
        {
            if(canFire && Input.GetKeyDown(KeyCode.KeypadEnter))
            {
                shoot();
                canFire = false;
                StartCoroutine(fireDelay());
            }
        }
    }

    void shoot()
    {
        GameObject shootingBall = Instantiate(
            shootingBallPrefab,
            firePoint.position,
            Quaternion.identity);

        Rigidbody rb = shootingBall.GetComponent<Rigidbody>();
        rb.AddForce(gameObject.transform.forward*10, ForceMode.Impulse);

        if (player2)
        {
            BallParameters ballScript = shootingBall.GetComponent<BallParameters>();
            ballScript.setPlayer2();
        }
    }
}
