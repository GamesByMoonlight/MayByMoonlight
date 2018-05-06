using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patron : MonoBehaviour {

    /* This class is used in conjunction with PatronSpawner to spawn.  It's extremely randomized, probably to a fault.
    *  Valuable improvement would be to adjust spawn rate based on a difficulty that is adjusted on the fly
    *  
    *  Could be a base class, IPatron?  I'm not the best with interfaces but I do know they exist.
    */

    public float advanceSpeed;
    public float seenEverySeconds;
    
	
	// Update is called once per frame
	void Update () {
        // Just to make the objects move to the left, for demo purposes

        var xPos = transform.position.x;
        xPos += advanceSpeed * Time.deltaTime;

        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
	}
}
