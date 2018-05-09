using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarktenderMovement : MonoBehaviour {

    public Transform[] playerLocations;

    KeyboardInputController inputController;

    void Start()
    {
        inputController = FindObjectOfType<KeyboardInputController>();
    }

	// Update is called once per frame
	void Update () {
        transform.position = playerLocations[inputController.Lane].position + new Vector3(0f, 1.2f, -0.1f);
	}
}
