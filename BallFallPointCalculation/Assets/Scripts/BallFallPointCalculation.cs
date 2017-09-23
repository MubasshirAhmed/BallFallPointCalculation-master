using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallFallPointCalculation : MonoBehaviour
{
    private static BallFallPointCalculation myInstance;

    public static BallFallPointCalculation MyInstance
    {
        get
        {
            if (myInstance == null)
                myInstance = FindObjectOfType<BallFallPointCalculation>();
            return myInstance;
        }
    }

    private bool ballNull = true;
    private float velocityMagnitude;
    private float angle;
    private float height;
    private float gravity = -9.81f;
    private Vector3 ballVelocity;
    private int count = 0;
    public GameObject FallPointObject;
    private Transform bBCP;

    public void FallPointCalculationMethod()
    {
        StartCoroutine(WaitSomeTime());
    }

    private IEnumerator WaitSomeTime()
    {
        bBCP = DataController.MyInstance.BallStatus.transform;
        yield return new WaitForSeconds(0.1f);
        FallPointCalculation();
    }

    private void FallPointCalculation()
    {
        ballVelocity = DataController.MyInstance.BallStatus.GetComponent<Rigidbody>().velocity;
        float displacementY = 0.0f - DataController.MyInstance.BallStatus.transform.position.y;
        velocityMagnitude = ballVelocity.magnitude;
        angle = (Mathf.Asin(ballVelocity.y / velocityMagnitude));
        height = ((Mathf.Pow((velocityMagnitude), 2)) * ((Mathf.Pow(Mathf.Sin(angle), 2)))) / (2 * 9.92f);
        float time = Mathf.Sqrt(-2 * height / gravity) + Mathf.Sqrt(2 * (displacementY - height) / gravity);
        Vector3 displacementXZ = new Vector3(ballVelocity.x, 0.0f, ballVelocity.z) * time;
        DataController.MyInstance.BallFallPoint = new Vector3(displacementXZ.x + bBCP.position.x, 0.0f, displacementXZ.z + bBCP.position.z);
        FallPointObject.transform.position = DataController.MyInstance.BallFallPoint;
    }
}

