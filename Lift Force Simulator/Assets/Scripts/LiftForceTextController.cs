using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LiftForceTextController : MonoBehaviour
{

    public TextMeshProUGUI LiftForceText;
    public DoubleVariable LiftForce;
	
	void Update ()
    {
        LiftForceText.text = "Lift force = " + LiftForce.Value.ToString("0.00") + " N";
	}
}
