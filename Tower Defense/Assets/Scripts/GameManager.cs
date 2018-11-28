using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    private bool gameOver;

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
        Debug.Log("Game over!");
        gameOver = true;
    }
}
