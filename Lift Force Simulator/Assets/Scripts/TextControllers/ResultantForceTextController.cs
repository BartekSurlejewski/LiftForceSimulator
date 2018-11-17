using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultantForceTextController : MonoBehaviour {

	// Use this for initialization
    public TextMeshProUGUI ResultantForceText;
    public DoubleVariable ResultantForce;
	
	void Update ()
    {
        ResultantForceText.text = "Resultant force = " + (ResultantForce.Value / 1000).ToString("0.00") + " kN";
	}
}
