using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyScaler : MonoBehaviour {

    private int _patrons = 1, _specialPatrons = 1;

    public int Patrons
    {
        get {
            return Mathf.Clamp(_patrons, 1, 100);
        }

    }

    public int SpecialPatrons {
        get {
            return _specialPatrons;
        }

    }
    
    public Text difficultyReadout;
    public Text patronsReadout;
    public Text specPatronsReadout;

    public float targetGameplaySeconds;

    public int patronsMultiplier = 3;
    public int specialPatronsMultiplier = 1;

    public int startingBucks = 100;
    public int bucksLossPerMinute = 500;
    private float buckLossAccumulator;

    private float _calculatedDifficulty;
    private float _timeMultiplier;
    
    private float _performanceIndicator;


    ScoreDisplay scoreDisplay;

	// Use this for initialization
	void Start () {
        scoreDisplay = FindObjectOfType<ScoreDisplay>();
        scoreDisplay.Bucks = startingBucks;
	}
	
	// Update is called once per frame
	void Update () {
        _performanceIndicator = scoreDisplay.Bucks * 60 / (targetGameplaySeconds * bucksLossPerMinute);

        _timeMultiplier = Time.timeSinceLevelLoad / targetGameplaySeconds;
        _calculatedDifficulty = _timeMultiplier * _performanceIndicator;

        difficultyReadout.text = _calculatedDifficulty.ToString("#.0");

        _patrons = Mathf.RoundToInt(patronsMultiplier * _calculatedDifficulty);
        patronsReadout.text = ("Patrons: " + Patrons);

        _specialPatrons = Mathf.RoundToInt(specialPatronsMultiplier * _calculatedDifficulty);
        specPatronsReadout.text = ("S. Patrons: " + SpecialPatrons);


        buckLossAccumulator += bucksLossPerMinute / 60 * Time.deltaTime;
        if (Mathf.RoundToInt(buckLossAccumulator) > 1)
        {
            scoreDisplay.SubtractBucks(Mathf.RoundToInt(buckLossAccumulator));
            buckLossAccumulator -= Mathf.RoundToInt(buckLossAccumulator);
        }


    }
}
