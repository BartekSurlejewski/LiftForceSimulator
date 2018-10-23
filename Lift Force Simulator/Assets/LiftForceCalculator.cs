using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftForceCalculator : MonoBehaviour
{

    public DoubleVariable AirDensity, AirfoilCoefficient, AttackAngle, Velocity, WingSurface;
    public double LiftForce = 0;

    void Update()
    {
        CalculateLiftForce();
    }

    public void CalculateLiftForce()
    {
        if (AirDensity && AirfoilCoefficient && AttackAngle && Velocity && WingSurface)
        {
            LiftForce = (2.0d * AirfoilCoefficient.Value * (AttackAngle.Value + 5.0d) * AirDensity.Value * WingSurface.Value * Mathf.Pow((float)Velocity.Value, 2)) / 2.0d;
        }

        Debug.Log(LiftForce);
    }
}
