using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftForceCalculator : MonoBehaviour
{
    private const double LocalAcceleration = 9.81;
    public DoubleVariable AirDensity, AirfoilCoefficient, AttackAngle, Velocity, WingSurface, LiftForceVariable, ResultantForceVariable, MassVariable;
    public GameObject FlyingObject;

    public GameObject FlyingObjectWings;

    private Rigidbody flyingObjectRb;

    private Quaternion originalRotation;

    private Vector3 originalScale;
    
    private double liftForce = 0;
    public double LiftForce
    {
        get { return liftForce; }
        set 
        { 
            if(value != liftForce || MassVariable)
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
        originalScale = FlyingObjectWings.transform.localScale;
        FlyingObject.transform.Rotate(new Vector3(0, 0, 1), (float) AttackAngle.Value);
    }

    void Update()
    {
        flyingObjectRb.mass = (float) MassVariable.Value;
        UpdateFlyingObject();
        CalculateLiftForce();
    }

    void UpdateFlyingObject()
    {
        FlyingObject.transform.localRotation = originalRotation;
        FlyingObject.transform.Rotate(new Vector3(1, 0, 0), (float) AttackAngle.Value);

        double defaultScale = 260;
        double scaleModifier = WingSurface.Value - defaultScale;

        FlyingObjectWings.transform.localScale = originalScale;
        FlyingObjectWings.transform.localScale += new Vector3(0, (float) scaleModifier * 0.001f, 0);
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
        ResultantForceVariable.Value = resultantForce;
     
        flyingObjectRb.velocity = Vector3.zero;
        flyingObjectRb.AddForce(new Vector3(0, (float) resultantForce, 0) * 50);
    }
}
