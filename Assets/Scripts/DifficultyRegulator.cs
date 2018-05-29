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

	public int CurrentMaxPatronCount = 3;

	public float SpawnChance = 0.5f;

	public float TimerSecondsCheck = 2f;

	public bool Break = false;

	public int StartingBucks = 300;

	public int MinPatronCount = 3;

	public int BreakTimeSeconds = 10;



    // Use this for initialization
    void Start () {
		this.Spawners = GameObject.Find("Bars").GetComponentsInChildren<PatronSpawner>();

        this.ScoreDisplay.Bucks = this.StartingBucks;
	}


	
	// Update is called once per frame
	void Update () {

		float gameTime = Time.timeSinceLevelLoad;	

		myTimer += Time.deltaTime;

		if (myTimer >= TimerSecondsCheck) {
			myTimer = 0;

			SpawnPatrons();
			KillPatrons();
			ReduceBucks();
		}

	}

	private void ReduceBucks() {
		this.ScoreDisplay.SubtractBucks(1);
	}

	public PatronSpawner GetRandomSpawner() {
		var i = Random.Range(0, this.Spawners.Length );
		return this.Spawners[i];
	}

	public GameObject GetRandomPatron() {
		var i = Random.Range(0, this.PatronPrefabs.Length);
		return  this.PatronPrefabs[i] ;
	}	

	bool ShouldSpawn() {
		if (this.Break) {
			return false;
		}

		if (CurrentPatrons.Count >= this.CurrentMaxPatronCount) {
			this.Break = true;
			Invoke("CancelBreak", this.BreakTimeSeconds);
			return false;
		}

		if (ScoreDisplay.Bucks > 100) {
			this.SpawnChance += 0.005f * ScoreDisplay.Bucks;
		} else {
			this.SpawnChance = 0.50f;
		}

		this.CurrentMaxPatronCount = this.ScoreDisplay.Bucks / 200;

		if (this.CurrentMaxPatronCount < MinPatronCount) {
			this.CurrentMaxPatronCount = MinPatronCount;
		}

		var i = Random.Range(0.0f, 1.0f);
		if (i <= this.SpawnChance) {
			return true;
		}
		return false;
	}

	private void CancelBreak() {
		this.Break = false;
		AdjustSpeed();
	}

	private void SpawnPatrons() {

		if (!this.ShouldSpawn()) {
			return;
		}

		var randomPatronPrefab = GetRandomPatron();
		
		var patronComponent = randomPatronPrefab.GetComponent<IPatron>();
		var spawnedPatron = GetRandomSpawner().Spawn( randomPatronPrefab); 
		spawnedPatron.GetComponent<IPatron>().MoveSpeed += CurrentPatronSpeed;
	}

	public float CurrentPatronSpeed = 0.0f;

	private void AdjustSpeed() {
		CurrentPatronSpeed = ScoreDisplay.Bucks / 1000 / 10;
		if (ScoreDisplay.Bucks < 500) {
			CurrentPatronSpeed = 0.0f;
		}
	}

	public int KillPatronXCoord = 10;
	public int PenaltyDenominator = 10;
	public int MinPenalty = 100;
	public int PissedPatronPenalty { 
		get { 
			var penalty = this.ScoreDisplay.Bucks / PenaltyDenominator;
			if (penalty < MinPenalty)
				penalty = MinPenalty;

			return penalty;
		}

	}

	public void KillPatrons() {
		var removed = new List<GameObject>();
		foreach(var patron in this.CurrentPatrons) {
			if (patron == null) {
				continue;
			}
			//TODO why do I need localPosition here?
			if (patron.transform.localPosition.x >= KillPatronXCoord) {
				ScoreDisplay.SubtractBucks(PissedPatronPenalty);
				Destroy(patron);
			}
		}
	}


}
