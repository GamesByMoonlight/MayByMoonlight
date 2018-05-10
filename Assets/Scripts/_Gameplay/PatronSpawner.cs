using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* This class takes an array of Patron objectsin the inspector.  
 * These objects should have a spawn rate that the spawner reads, and RNG that determines whether they spawn.
 * This causes messy spawn rates and fluctuations of sometimes too many spawns, sometimes too few.
 */

public class PatronSpawner : MonoBehaviour {

    public GameObject[] patronPrefabArray;
        
	void Update ()
	{
		foreach (GameObject myPatron in patronPrefabArray) {
			if (IsTimeToSpawn (myPatron)){
				Spawn(myPatron);
			}
		}
	}

	public void Spawn (GameObject myGameObject)	{
		GameObject spawn = Instantiate(myGameObject);
		spawn.transform.parent = gameObject.transform;
		spawn.transform.position = transform.position;
	}

	bool IsTimeToSpawn (GameObject attackerSpawnCooldown)
	{
		Patron patronScript = attackerSpawnCooldown.GetComponent<Patron> ();

		float meanSpawnDelay = patronScript.seenEverySeconds;
		float spawnsPerSecond = 1 / meanSpawnDelay;

		if (Time.deltaTime > meanSpawnDelay) {
			Debug.LogWarning ("Spawn rate capped by frame rate");
		} 

		float threshold = spawnsPerSecond * Time.deltaTime / 5;

		if (Random.value < threshold) {
			return true;
		} else {
			return false;
		}
	}
}
