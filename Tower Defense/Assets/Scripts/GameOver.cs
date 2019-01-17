using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour {
    [SerializeField] Text roundSurvivedText;
    [SerializeField] SceneFader sceneFader;
    [SerializeField] string menuSceneName = "Main Menu";

    private void OnEnable()
    {
        roundSurvivedText.text = PlayerStat.rounds.ToString();
    }

    public void Retry()
    {
        sceneFader.FadeTo(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void ReturnMenu()
    {
        sceneFader.FadeTo(menuSceneName);
        Time.timeScale = 1;
    }
}
