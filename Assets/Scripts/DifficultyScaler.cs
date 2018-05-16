using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyScaler : MonoBehaviour {

    /* A little bit of math wizardry to try to start balancing # of patrons on screen with respect to player's performance, and target game time
     * Patrons, SpecialPatrons are a reference for the spawners
     * 
     * Formulas are just for testing purposes for now, should be tweaked based on feedback and when 
     * */

    private int _patrons = 1, _specialPatrons = 1;

    public int Patrons
    {
        get {
            // Guarantee at least 1 patron always
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

    // Poor performance during this time period should slow down gameplay accordingly (to guarantee at least a certain minimum play time)
    public float targetGameplaySeconds = 60;

    public int patronsMultiplier = 3;
    public int specialPatronsMultiplier = 1;

    public int startingBucks = 100;
    public int bucksLossPerMinute = 500;
    private float buckLossAccumulator;

    private float _calculatedDifficulty;
    private float _timeMultiplier = 1;
    private float _performanceIndicator;

    ScoreDisplay scoreDisplay;

	// Use this for initialization
	void Start () {
        scoreDisplay = FindObjectOfType<ScoreDisplay>();
        scoreDisplay.Bucks = startingBucks;
	}
	
	// Update is called once per frame
	void Update () {
        // Performance indicator is how far away the player is from going broke in 30 seconds due to cash loss
        // 1 means "going broke in 30 seconds", 2 means "going broke in 1 minute"
        _performanceIndicator = scoreDisplay.Bucks / (2f * bucksLossPerMinute);
        
        float gameTime = Time.timeSinceLevelLoad;

        if (targetGameplaySeconds != 0)
                _timeMultiplier = (gameTime < targetGameplaySeconds) ? gameTime/targetGameplaySeconds : gameTime / 60;
        
        if (_timeMultiplier < 1 && _performanceIndicator < 1)
        {
            _calculatedDifficulty = _timeMultiplier;
        }
        else
        {
            _calculatedDifficulty = _timeMultiplier * _performanceIndicator;
        }

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
