using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour {
    [SerializeField] SceneFader sceneFader;
    [SerializeField] string menuSceneName = "Main Menu";

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
