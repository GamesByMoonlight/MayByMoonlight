using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DifficultyRegulator : MonoBehaviour {

	[System.Serializable]
	public class Wave
	{
		public int Level = 1;

		[SerializeField]
		public float SpawnBreak ;

		public float PatronMultiplier ;

		public int MimNumberOfPatrons ;

		//field is only there to be visible in the UI
		public int _maxNumberOfPatronsForThisWave ;
		public int MaxNumberOfPatronsForThisWave { 
			get {
				var val = System.Convert.ToInt32( Level * PatronMultiplier );
				if (val < MimNumberOfPatrons) {
					val = MimNumberOfPatrons;
				}

				_maxNumberOfPatronsForThisWave = val;
				return val;
			}
		}


		public int PatronsLeftToSpawn ;

		public float PatronSpeedIncreasePerWave = 0.05f;

		//ony for visibility in ui, can remove later
		public float _patronSpeedIncreaseCurrent;
		public float PatronSpeedIncreaseCurrent { 
			get {
				_patronSpeedIncreaseCurrent = Level * PatronSpeedIncreasePerWave;
				return _patronSpeedIncreaseCurrent;
			}
		}

		public float PatronSpeedModifier { 
			get {
				return Level * PatronSpeedIncreasePerWave;
			}
		}

		public bool AlertPatronSpawned() {
			this.PatronsLeftToSpawn -=1;
			if (this.PatronsLeftToSpawn <= 0) {

				return true;
			}

			return false;
		}

		public int NumberOfBucksPerLevel = 500;

		public void IncrementLevel(int currentBucks) {
			this.Level = currentBucks / NumberOfBucksPerLevel;
			// this.Level +=1;
			this.PatronsLeftToSpawn = MaxNumberOfPatronsForThisWave;
		}


	}

    public ScoreDisplay ScoreDisplay;

	private PatronSpawner[] Spawners;

	public GameObject[] PatronPrefabs;
	public IList<GameObject> CurrentPatrons {
		get {
			return GameObject.FindGameObjectsWithTag("Patron");
		}
	}


	private float myTimer = 0.0f;



	public float TimerSecondsCheck = 2f;

	public bool Break = false;

	public int StartingBucks = 300;


	[SerializeField]
	public Wave CurrentWave = new Wave();

	// Use this for initialization
	void Start () {

		this.Spawners = GameObject.Find("Bars").GetComponentsInChildren<PatronSpawner>();

        this.ScoreDisplay.Bucks = this.StartingBucks;
	}


	
	// Update is called once per frame
	void Update () {

		SpawnTimer += Time.deltaTime;
		myTimer += Time.deltaTime;

		if (myTimer >= TimerSecondsCheck) {
			myTimer = 0;

			SpawnPatrons();
			// KillPatrons();
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


	public float SpawnTimer = 0.0f;

	public float DelayBetweenSpawns;


	public bool CancelBreakStarted;

	bool ShouldSpawn() {
		if (this.Break  ) {
			if (this.CurrentPatrons.Count == 0 && !this.CancelBreakStarted) {
				this.CancelBreakStarted = true;
				Invoke("CancelBreak", this.CurrentWave.SpawnBreak);
			}
			return false;
		}

		if (this.CurrentWave.PatronsLeftToSpawn <= 0) {
			this.StartBreak();
			return false;
		}

		// if (CurrentPatrons.Count >= this.CurrentMaxPatronCount) {
		// 	this.Break = true;
		// 	Invoke("CancelBreak", this.BreakTimeSeconds);
		// 	return false;
		// }


		if (SpawnTimer >= DelayBetweenSpawns) {
			this.SpawnTimer = 0;
			return true;
		}


		return false;
	}

	private void StartBreak() {
		this.CancelBreakStarted = false;
		this.Break = true;		
	}
	private void CancelBreak() {
		this.Break = false;
		this.CurrentWave.IncrementLevel(this.ScoreDisplay.Bucks);
		// AdjustSpeed();
	}

	// public float MinimumSpeedDivisor = 10.0f;
	private void SpawnPatrons() {

		if (!this.ShouldSpawn()) {
			return;
		}

		var randomPatronPrefab = GetRandomPatron();
		
		var patronComponent = randomPatronPrefab.GetComponent<IPatron>();
		var spawnedPatron = GetRandomSpawner().Spawn( randomPatronPrefab); 
		spawnedPatron.GetComponent<IPatron>().MoveSpeed += 
			Random.Range( 0.5f * this.CurrentWave.PatronSpeedIncreaseCurrent, 2f * this.CurrentWave.PatronSpeedIncreaseCurrent );

		this.CurrentWave.AlertPatronSpawned();
	}

	// public float CurrentPatronSpeed = 0.0f;

	// public int MinimumBucksToAdjustSpeed = 500;

	// public float PatronSpeedBucksDivisor = 10000f;

	// private void AdjustSpeed() {
		// CurrentPatronSpeed = ScoreDisplay.Bucks / PatronSpeedBucksDivisor ;
		// if (ScoreDisplay.Bucks < MinimumBucksToAdjustSpeed) {
		// 	CurrentPatronSpeed = 0.0f;
		// }


	// }

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

	// public void KillPatrons() {
	// 	var removed = new List<GameObject>();
	// 	foreach(var patron in this.CurrentPatrons) {
	// 		if (patron == null) {
	// 			continue;
	// 		}
	// 		//TODO why do I need localPosition here?
	// 		if (patron.transform.localPosition.x >= KillPatronXCoord) {
	// 			ScoreDisplay.SubtractBucks(PissedPatronPenalty);
	// 			Destroy(patron);
	// 		}
	// 	}
	// }


}
