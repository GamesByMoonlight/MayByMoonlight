using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public CanvasGroup GameOverWindowCG;
    public CanvasGroup GameOverHighScoreCG;

    void Start()
    {
        GameEventSystem.Instance.GameEnded.AddListener(GameEndedListener);
        GameOverWindowCG.alpha = 0f;
        GameOverWindowCG.interactable = false;
        GameOverWindowCG.blocksRaycasts = false;
        GameOverHighScoreCG.alpha = 0f;
        GameOverHighScoreCG.interactable = false;
        GameOverHighScoreCG.blocksRaycasts = false;
    }

    void GameEndedListener()
    {
        if (PlayerPrefsManager.CheckForHighScore(FindObjectOfType<ScoreDisplay>().Score))
        {
            GameOverHighScoreCG.alpha = 1f;
            GameOverHighScoreCG.interactable = true;
            GameOverHighScoreCG.blocksRaycasts = true;
        }
        else
        {
            GameOverWindowCG.alpha = 1f;
            GameOverWindowCG.interactable = true;
            GameOverWindowCG.blocksRaycasts = true;
        }
        
    }

    
    public void Restart()
    {
        SceneManager.LoadScene("01_Start");
    }


    private void OnDestroy()
    {
        if(GameEventSystem.Instance != null)
            GameEventSystem.Instance.GameEnded.RemoveListener(GameEndedListener);
    }
}
