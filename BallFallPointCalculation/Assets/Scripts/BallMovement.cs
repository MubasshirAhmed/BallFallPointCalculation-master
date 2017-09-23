using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && DataController.MyInstance.BallStatus != null)
        {
            BallScript ballScript = GameObject.FindObjectOfType<BallScript>();
            ballScript.BallThrowMethod();
        }
        else if (Input.GetKeyDown(KeyCode.Space) && DataController.MyInstance.BallStatus == null)
        {
            Debug.Log("Ball Not Found.");
        }
    }
}
