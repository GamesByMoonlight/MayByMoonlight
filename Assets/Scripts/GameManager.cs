using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public CanvasGroup GameOverWindowCG;

    void Start()
    {
        GameEventSystem.Instance.GameEnded.AddListener(GameEndedListener);
        GameOverWindowCG.alpha = 0f;
        GameOverWindowCG.interactable = false;
        GameOverWindowCG.blocksRaycasts = false;
    }

    void GameEndedListener()
    {
        GameOverWindowCG.alpha = 1f;
        GameOverWindowCG.interactable = true;
        GameOverWindowCG.blocksRaycasts = true;
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
