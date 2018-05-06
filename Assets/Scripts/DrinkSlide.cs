using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkSlide : MonoBehaviour {

    public Rigidbody rb;
    public float xVel = 8000;

    private Vector3 startPos;

	// Use this for initialization
	void Start () {
        // store the starting location for reset
        //startPos = new Vector3(rb.transform.position.x, rb.transform.position.y, rb.transform.position.z);
        //rb.AddForce(xVel, 0, 0);

    }
	
	// Update is called once per frame
	void Update () {

    }

}
