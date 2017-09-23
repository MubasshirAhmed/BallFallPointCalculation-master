using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallCreator : MonoBehaviour
{
    public GameObject ballGO;
    public static GameObject ball;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C) && ball==null)
        {
            ball = Instantiate(ballGO, transform.position, transform.rotation);
            ball.GetComponent<Rigidbody>().useGravity = false;
        }
    }
}
