using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataController : MonoBehaviour
{

    private static DataController myInstance;

    public static DataController MyInstance
    {
        get
        {
            if (myInstance == null)
                myInstance = FindObjectOfType<DataController>();
            return myInstance;
        }
    }

    private Vector3 ballFallPoint;
    private GameObject ballStatus;
    private bool ballCollideWithBat;
    private bool ballCollideWithPlane;
    private bool ballFallPointCalculationStatus;

    public GameObject BallStatus
    {
        get { return BallCreator.ball; }
    }

    public bool BallCollideWithBat
    {
        get { return BallCollideWithBat; }
        set { ballCollideWithBat = value; }
    }

    public Vector3 BallFallPoint
    {
        get {return ballFallPoint; }
        set {ballFallPoint = value; }
    }

    public bool BallFallPointCalculationStatus
    {
        get { return BallCollideWithBat; }
        set { ballCollideWithBat = value; }
    }
}
