using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSceneSetter : MonoBehaviour {

	public string nameOfScene;

	private LevelManager levelManager;

	void Start(){
		levelManager = FindObjectOfType<LevelManager>();
		levelManager.SetToActiveScene(nameOfScene);
	}
}
