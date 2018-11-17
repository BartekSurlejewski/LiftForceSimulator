using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour {
      
	public GameObject FlyingObject;

    private float backgroundWidth;   
	private float backgroundHeight;    

    private void Awake ()
    {
        backgroundWidth = GetComponent<Renderer>().bounds.size.x;
		backgroundHeight = GetComponent<Renderer>().bounds.size.y;
    }

    private void Update()
    {
        if (transform.position.x < -backgroundWidth)
        {
            MoveBackgroundRight();
        }
		
		if(FlyingObject.transform.position.y > backgroundHeight)
		{
			// MoveBackgroundUp();
		}
    }

    private void MoveBackgroundRight()
    {
        float groundOffSet = backgroundWidth * 2f;
		transform.position = new Vector3(transform.position.x + groundOffSet, transform.position.y, transform.position.z);
    }

	private void MoveBackgroundUp()
    {
        float groundOffSet = backgroundHeight * 2f;
		transform.position = new Vector3(transform.position.x, transform.position.y + groundOffSet, transform.position.z);
    }
}
