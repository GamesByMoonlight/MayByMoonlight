using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyScaler : MonoBehaviour {

    public Text difficultyReadout;
    
    public float targetGameplaySeconds;

    public int patronsOnscreen = 3;
    public int maxSpecialPatrons = 1;

    private float _calculatedDifficulty;
    private float _timeMultiplier;

    ScoreDisplay scoreDisplay;

	// Use this for initialization
	void Start () {
        scoreDisplay = FindObjectOfType<ScoreDisplay>();
	}
	
	// Update is called once per frame
	void Update () {
        _timeMultiplier = Time.timeSinceLevelLoad > targetGameplaySeconds ? 1 : Time.timeSinceLevelLoad / targetGameplaySeconds;
        _calculatedDifficulty = _timeMultiplier;


        difficultyReadout.text = _calculatedDifficulty.ToString("#.0");
	}
}
