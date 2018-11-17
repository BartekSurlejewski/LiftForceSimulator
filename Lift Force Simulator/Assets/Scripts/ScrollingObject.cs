using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour {

	public DoubleVariable FlyingObjectVelocity;

    private Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

    void Update () 
    {
        rb.velocity = new Vector3(-5 * ((float) FlyingObjectVelocity.Value), 0, 0);
    }
}
