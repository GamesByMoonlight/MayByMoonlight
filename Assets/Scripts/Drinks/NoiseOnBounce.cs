using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoiseOnBounce : MonoBehaviour {
    public float LateralBounceNoise = 5f;
	// Use this for initialization
	void Start () {
		
	}

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.GetComponent<IMixedDrink>() != null)
        {
            var rb = collision.gameObject.GetComponent<Rigidbody>().velocity += new Vector3(0f, 0f, Random.Range(-LateralBounceNoise, LateralBounceNoise));;
        }

    }
}
