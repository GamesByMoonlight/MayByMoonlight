using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cat : MonoBehaviour {
    public float LateralBounceNoise = 5f;
    public Animator Anim;
    public float SpawnTime = 7f;
    public float Noise = 2f;
    public Transform[] SpawnPoints;

    float lastTriggerTime;

    private void Start()
    {
        StartCoroutine(Spawn(SpawnTime + Random.Range(-Noise, Noise)));
    }

    IEnumerator Spawn(float time)
    {
        yield return new WaitForSeconds(time);
        transform.position = SpawnPoints[Random.Range(0,SpawnPoints.Length)].position;
        StartCoroutine(Spawn(SpawnTime + Random.Range(-Noise, Noise)));
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
