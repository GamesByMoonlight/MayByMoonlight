using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrinkDestroyer : MonoBehaviour {

    // Lifetime is a basic remover before all the colliders are added to ensure objects don't pile up and clog memory.
    // Remove this when all colliders are in.
    float lifetime = 0.0f;
    float maxLifetime = 3.0f;
	
	// Update is called once per frame
	void Update () {

        lifetime += Time.deltaTime;
        if (lifetime > maxLifetime)
            Destroy(this.gameObject);
		
	}


    private void OnCollisionEnter(Collision collision)
    {
        // Debug.Log(collision.collider.tag);

        if (collision.collider.tag == "Floor" || collision.collider.tag == "Patron")
            Destroy(this.gameObject);

        if (collision.collider.tag == "Cat")
        {
            // Knock it forward off the bar if it collides with a Cat patron.
            Rigidbody rb = this.GetComponent<Rigidbody>();
            rb.AddForce(0, 0, -500);
            
        }
           

    }
}
