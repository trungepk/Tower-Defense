using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] GameObject gameOverUI;
    [SerializeField] string nextLevel;
    [SerializeField] int levelToUnlock;
    [SerializeField] SceneFader sceneFader;

    public static bool gameOver;

    private void Start()
    {
        gameOver = false;
    }

    private void Update()
    {
        if (gameOver)
            return;

        if (PlayerStat.lives <= 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        gameOver = true;
        gameOverUI.SetActive(true);
    }

    public void WonGame()
    {
        Debug.Log("WON!");
        PlayerPrefs.SetInt("levelReached", levelToUnlock);
        sceneFader.FadeTo(nextLevel);
    }
}
