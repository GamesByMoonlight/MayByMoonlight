using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public string nextLevel;
	public static int levelIndex;


	public void LoadNextLevel (){
		SceneManager.UnloadSceneAsync(levelIndex);
		levelIndex++;
		SceneManager.LoadScene(levelIndex, LoadSceneMode.Additive);
		}

	public void LoadLevel (string name) {
		//Debug.Log("Level load requested for: " + name);  	// debug purposes

		SceneManager.UnloadSceneAsync(levelIndex);
		SceneManager.LoadScene(name, LoadSceneMode.Additive);

		levelIndex = SceneManager.GetSceneByName(name).buildIndex;						// According to the lecture 6 q&A this should replace Application.LoadLevel

	}

	public void LoadSplash ()	{
		SceneManager.LoadScene("00 Splash", LoadSceneMode.Additive);
		levelIndex = 1;
	}

	public void QuitRequest ()	{
		Debug.Log("Quit Request");
		Application.Quit();
	}

	public void SendToActiveScene (GameObject objectToDeliver){
		SceneManager.MoveGameObjectToScene(objectToDeliver, SceneManager.GetActiveScene());
	}

	public void SetToActiveScene (string sceneName)	{
		SceneManager.SetActiveScene (SceneManager.GetSceneByName(sceneName));
	}

}
