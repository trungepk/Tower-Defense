using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField] GameObject gameOverUI;

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
}
