using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashScreen : MonoBehaviour {

	// Use this for initialization
	void Start () {
        StartCoroutine(TransitionToStart());
	}
	
	IEnumerator TransitionToStart()
    {
        yield return new WaitForSeconds(5.5f);

        SceneManager.LoadScene(1);
    }
}
