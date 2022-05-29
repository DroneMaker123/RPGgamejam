using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonControls : MonoBehaviour
{
    [SerializeField]
    bool player2 = false;

    Vector3 cannonRotation;

    [SerializeField]
    float horizontalRotationSpeed = 70;
    [SerializeField]
    float verticalRotationSpeed = 50;
    [SerializeField]
    float returnRotationSpeed = 25;

    private Vector3 originRotationP1 = new Vector3(0, 0, 0);
    private Vector3 originRotationP2 = new Vector3(0, 180, 0);

    private void Start()
    {
        if (!player2) cannonRotation = originRotationP1;
        else cannonRotation = originRotationP2;
    }

    private void Update()
    {
        inputsControl();
        setNewRotation();
        returnRotation(); 

    }
    
    //Changes the cannonRotation vector according to player inputs
    void inputsControl() 
    {

        if (!player2) //Inputs for Player1
        {
            if(Input.GetKey(KeyCode.W))
            {
                cannonRotation.x -= verticalRotationSpeed * Time.deltaTime; 
            }
            if(Input.GetKey(KeyCode.S))
            {
                cannonRotation.x += verticalRotationSpeed * Time.deltaTime;
            }
            
            if(Input.GetKey(KeyCode.A))
            {
                cannonRotation.y -= horizontalRotationSpeed * Time.deltaTime;
            }
            if(Input.GetKey(KeyCode.D))
            {
                cannonRotation.y += horizontalRotationSpeed * Time.deltaTime;
            }
            
        }
        else //Inputs for Player2
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                cannonRotation.x -= verticalRotationSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                cannonRotation.x += verticalRotationSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                cannonRotation.y -= horizontalRotationSpeed * Time.deltaTime;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                cannonRotation.y += horizontalRotationSpeed * Time.deltaTime;
            }
        }
    }
    void setNewRotation()
    {
        //Edge cases
        if (cannonRotation.x > 0) cannonRotation.x = 0;
        else if (cannonRotation.x < -90) cannonRotation.x = -90;

        if(!player2)
        {
            if (cannonRotation.y > 90) cannonRotation.y = 90;
            else if (cannonRotation.y < -90) cannonRotation.y = -90;
        }
        else
        {
            if (cannonRotation.y > 270) cannonRotation.y = 270;
            else if (cannonRotation.y < 90) cannonRotation.y = 90;
        }

        gameObject.transform.localEulerAngles = cannonRotation; //Sets gameobject rotation

    }
    void returnRotation() //return rotation to originRotation
    {
        if (!player2) cannonRotation = Vector3.MoveTowards(cannonRotation, originRotationP1, returnRotationSpeed * Time.deltaTime);
        else cannonRotation = Vector3.MoveTowards(cannonRotation, originRotationP2, returnRotationSpeed * Time.deltaTime);
    }
}
