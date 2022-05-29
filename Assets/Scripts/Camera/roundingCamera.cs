using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class roundingCamera : MonoBehaviour
{

    float time = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime/2;
        Vector3 pos = gameObject.transform.position;
        pos.x = 40 * Mathf.Sin(time);
        pos.z = 40 * Mathf.Cos(time);

        gameObject.transform.position = pos;

        Vector3 rot = gameObject.transform.eulerAngles;
        rot.y = time*180/Mathf.PI +180;
        gameObject.transform.eulerAngles = rot;

    }
}
