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
	public IList<GameObject> CurrentPatrons {
		get {
			return GameObject.FindGameObjectsWithTag("Patron");
		}
	}

	// public float SpeedModifier = -0.2f;

	private float myTimer = 0.0f;

	public int MaxPatronCount = 10;

	public float SpawnChance = 0.5f;

	// Use this for initialization
	void Start () {
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
		if (ScoreDisplay.Bucks > 100) {
			this.SpawnChance += 0.1f * ScoreDisplay.Bucks;
		} else {
			this.SpawnChance = 0.50f;
		}

		var i = Random.Range(0.0f, 1.0f);
		if (i <= this.SpawnChance) {
			return true;
		}
		return false;
	}

	public void SpawnPatrons() {
		Debug.Log(CurrentPatrons.Count);
		if (CurrentPatrons.Count >= this.MaxPatronCount) {
			return;
		}

		if (!this.ShouldSpawn()) {
			return;
		}

		var randomPatronPrefab = GetRandomPatron();
		
		var patronComponent = randomPatronPrefab.GetComponent<IPatron>();

		// if (patronComponent.MoveSpeed >  0) {

		// 	patronComponent.MoveSpeed += SpeedModifier;
		// }
		// else {
		// 	SpeedModifier = 0f;
		// 	patronComponent.MoveSpeed = 0.5f;
		// }

		// Debug.Log(patronComponent.MoveSpeked);

		var spawnedPatron = GetRandomSpawner().Spawn( randomPatronPrefab); 

	}

	public int KillXCoordinate = 12;
	public void KillPatrons() {
		var removed = new List<GameObject>();
		foreach(var patron in this.CurrentPatrons) {
			if (patron == null) {
				continue;
			}
			//TODO why do I need localPosition here?
			if (patron.transform.localPosition.x >= KillXCoordinate) {
				ScoreDisplay.Bucks -= 50;
				Destroy(patron);
			}
		}
	}


}
