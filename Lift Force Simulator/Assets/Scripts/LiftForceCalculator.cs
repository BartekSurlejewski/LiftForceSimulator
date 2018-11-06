using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftForceCalculator : MonoBehaviour
{
    private const double LocalAcceleration = 9.81;
    public DoubleVariable AirDensity, AirfoilCoefficient, AttackAngle, Velocity, WingSurface, LiftForceVariable, MassVariable;
    public GameObject FlyingObject;

    private Rigidbody flyingObjectRb;

    private Quaternion originalRotation;
    
    private double liftForce = 0;
    public double LiftForce
    {
        get { return liftForce; }
        set 
        { 
            if(value != liftForce)
            {   
                liftForce = value;
                ApplyForceToObject();
            }
        }
    }

    void Start()
    {
        flyingObjectRb = FlyingObject.GetComponent<Rigidbody>();
        originalRotation = FlyingObject.transform.rotation;
        FlyingObject.transform.Rotate(new Vector3(0, 0, 1), (float) AttackAngle.Value);
    }

    void Update()
    {
        flyingObjectRb.mass = (float) MassVariable.Value;
        CalculateLiftForce();
        Debug.Log("Lift force: " + LiftForce + " Velocity: " + flyingObjectRb.velocity);
    }

    void CalculateLiftForce()
    {
        if (AirDensity && AirfoilCoefficient && AttackAngle && Velocity && WingSurface)
        {
            LiftForce = (2.0d * AirfoilCoefficient.Value * (AttackAngle.Value + 5.0d) * AirDensity.Value * WingSurface.Value * Mathf.Pow((float)Velocity.Value, 2)) / 2.0d;
        }
		
		LiftForceVariable.Value = LiftForce;
    }

    void ApplyForceToObject()
    {
        double resultantForce = LiftForce - (MassVariable.Value * LocalAcceleration);
     
        flyingObjectRb.velocity = Vector3.zero;
        flyingObjectRb.AddForce(new Vector3(0, (float) resultantForce, 0) * 50);

        FlyingObject.transform.localRotation = originalRotation;
        FlyingObject.transform.Rotate(new Vector3(0, 0, 1), (float) AttackAngle.Value);
    }
}
