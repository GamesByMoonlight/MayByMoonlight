using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DifficultyRegulator : MonoBehaviour {


	public int TotalNumberOfPatrons;
	public int ScoreInLastNSeconds;  // how many points in last N seconds, N defined by sccore time threshold
    public ScoreDisplay ScoreDisplay;
	public int ScoreTimeThreshold = 10; //how many seconds w/o scoring before we're concerned.

	private PatronSpawner[] Spawners;

	public GameObject[] PatronPrefabs;
	public IList<GameObject> CurrentPatrons;

	public float SpeedModifier = -0.5f;

	private float myTimer = 0.0f;

	// Use this for initialization
	void Start () {
		this.CurrentPatrons = new List<GameObject>();
		this.Spawners = GameObject.Find("Bars").GetComponentsInChildren<PatronSpawner>();
	}


	
	// Update is called once per frame
	void Update () {

		float gameTime = Time.timeSinceLevelLoad;	

		myTimer += Time.deltaTime;

		if (myTimer >= 1) {
			myTimer = 0;

			SpawnPatrons();
			KillPatrons();
		}

	}

	public PatronSpawner GetRandomSpawner() {
		var i = Random.Range(0, this.Spawners.Length );
		return this.Spawners[i];
	}

	public GameObject GetRandomPatron() {
		var i = Random.Range(0, this.PatronPrefabs.Length);
		return  this.PatronPrefabs[i] ;
	}	

	public bool ShouldSpawn() {
		return false;
	}

	public void SpawnPatrons() {
		if (CurrentPatrons.Count > 0) {
			return;
		}
		var randomPatronPrefab = GetRandomPatron();
		
		var patronComponent = randomPatronPrefab.GetComponent<IPatron>();

		// if (patronComponent.MoveSpeed >  0.2) {

		// 	patronComponent.MoveSpeed += SpeedModifier;
		// }
		// else {
		// 	SpeedModifier = 0f;
		// }

		// Debug.Log(patronComponent.MoveSpeed);

		var spawnedPatron = GetRandomSpawner().Spawn( randomPatronPrefab); 
		this.CurrentPatrons.Add(spawnedPatron);

	}

	public int KillXCoordinate = 12;
	public void KillPatrons() {
		var removed = new List<GameObject>();
		foreach(var patron in this.CurrentPatrons) {
			//TODO why do I need localPosition here?
			if (patron.transform.localPosition.x >= KillXCoordinate) {
				Destroy(patron);
				removed.Add(patron);
			}
		}


		foreach(var patron in removed) {
			this.CurrentPatrons.Remove(patron);	
		}
	}


}
