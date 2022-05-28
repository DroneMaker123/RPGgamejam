using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonControls : MonoBehaviour
{
    [SerializeField]
    bool player2 = false;

    Vector3 cannonRotation;

    [SerializeField]
    float horizontalRotationSpeed = 1;
    [SerializeField]
    float verticalRotationSpeed = 1;
    [SerializeField]
    float returnRotationSpeed = 0.05f;


    private Vector3 originRotationP1 = new Vector3(0, 90, 0);
    private Vector3 originRotationP2 = new Vector3(0, -90, 0);

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
                cannonRotation.x += verticalRotationSpeed; 
            }
            if(Input.GetKey(KeyCode.S))
            {
                cannonRotation.x -= verticalRotationSpeed;
            }
            
            if(Input.GetKey(KeyCode.A))
            {
                cannonRotation.y += horizontalRotationSpeed;
            }
            if(Input.GetKey(KeyCode.D))
            {
                cannonRotation.y -= horizontalRotationSpeed;
            }
            
        }
        else //Inputs for Player2
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                cannonRotation.x += verticalRotationSpeed;
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                cannonRotation.x -= verticalRotationSpeed;
            }
            if (Input.GetKey(KeyCode.LeftArrow))
            {
                cannonRotation.y += horizontalRotationSpeed;
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                cannonRotation.y -= horizontalRotationSpeed;
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
            if (cannonRotation.y > 180) cannonRotation.y = 180;
            else if (cannonRotation.y < 0) cannonRotation.y = 0;
        }
        else
        {
            if (cannonRotation.y > 0) cannonRotation.y = 0;
            else if (cannonRotation.y < -180) cannonRotation.y = -180;
        }

        gameObject.transform.localEulerAngles = cannonRotation; //Sets gameobject rotation

    }
    void returnRotation() //return rotation to originRotation
    {
        if (!player2) cannonRotation = Vector3.MoveTowards(cannonRotation, originRotationP1, returnRotationSpeed);
        else cannonRotation = Vector3.MoveTowards(cannonRotation, originRotationP2, returnRotationSpeed);
    }
}
