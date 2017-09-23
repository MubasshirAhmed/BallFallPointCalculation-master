using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 ballVelocity;
    private TrailRenderer tr;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ballVelocity = new Vector3(-1.6f, -3.2f, -35.1f);
        tr = GetComponent<TrailRenderer>();
    }

    public void BallThrowMethod()
    {
        if (gameObject.transform.position != new Vector3(0.48f, 1.52f, 10.0f))
        {
            DataController.MyInstance.BallCollideWithBat = false;
            tr.enabled = false;
            rb.useGravity = false;
            rb.velocity = Vector3.zero; ;
            rb.angularVelocity = Vector3.zero;
            transform.position = new Vector3(0.48f, 1.52f, 10.0f);
        }
        else if (gameObject.transform.position == new Vector3(0.48f, 1.52f, 10.0f))
        {
            tr.enabled = true;
            rb.useGravity = true;
            rb.velocity = ballVelocity;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.name == "Plane")
        {
            tr.enabled = false;
            rb.useGravity = false;
            rb.velocity = Vector3.zero; ;
            rb.angularVelocity = Vector3.zero;
        }
        else if (other.gameObject.name == "CreaseReal")
        {
            rb.velocity = new Vector3(1f, 5f, -35.1f);
        }
        else if (other.gameObject.name == "Bat")
        {
            BallFallPointCalculation.MyInstance.FallPointCalculationMethod();
        }
    }
}
