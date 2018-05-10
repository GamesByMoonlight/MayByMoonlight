using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FancyPatron : MonoBehaviour, IPatron {

    public float WhiskeyValue = 0f;
    public float VodkaValue = 0f;
    public float RumValue = 0f;
    public float SodaValue = 0f;
    public float CokeValue = 0f;
    public float VermouthValue = 0f;
    public Garnish TypeOfGarnish = Garnish.Lime;

    public float advanceSpeed = 4;

    public float MoveSpeed { get { return advanceSpeed; } set { advanceSpeed = value; } }

    // Update is called once per frame
    void Update () {
        var xPos = transform.position.x;
        xPos += advanceSpeed * Time.deltaTime;

        transform.position = new Vector3(xPos, transform.position.y, transform.position.z);
    }
}
