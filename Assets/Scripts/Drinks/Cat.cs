using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour {
    public float LateralBounceNoise = 5f;
    public Animator Anim;

    float lastTriggerTime;

    private void Start()
    {
        
    }

    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.GetComponent<IMixedDrink>() != null)
        {
            collision.gameObject.GetComponent<Rigidbody>().velocity += new Vector3(0f, 0f, Random.Range(-LateralBounceNoise, LateralBounceNoise));
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<IMixedDrink>() == null)
            return;
        
        if(Time.time - lastTriggerTime > .1f)
        {
            lastTriggerTime = Time.time;
            Anim.SetTrigger("DrinkInbound");
        }
    }
}
