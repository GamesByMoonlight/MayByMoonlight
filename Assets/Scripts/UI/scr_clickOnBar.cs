using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scr_clickOnBar : MonoBehaviour 
{
    Ray ray;
    RaycastHit hit;

	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ray, out hit))
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (hit.collider.tag == "Bar1")
                    Debug.Log("You Hit the bar");
                else
                    Debug.Log("You get nothing");
            }
        }
	}
}
