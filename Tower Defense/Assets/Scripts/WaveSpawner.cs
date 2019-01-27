using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    [SerializeField] Wave[] waves;
    [SerializeField] Transform startPos;
    [SerializeField] float timeBetweenWaves = 5f;
    [SerializeField] float countdown = 2f;
    [SerializeField] Text waveCountdownText;
    [SerializeField] GameManager gameManager;
    public static int EnemyAvailable;

    private int waveIndex;

    private void Start()
    {
        EnemyAvailable = 0;
    }

    private void Update()
    {
        if (EnemyAvailable > 0) return;
        if (waveIndex == waves.Length)
        {
            gameManager.WonGame();
            enabled = false;
        }
        if (countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
            return;
        }
        countdown -= Time.deltaTime;
        countdown = Mathf.Clamp(countdown, 0f, Mathf.Infinity);
        waveCountdownText.text = string.Format("{0:00.00}", countdown);
    }

    IEnumerator SpawnWave()
    {
        Wave wave = waves[waveIndex];
        PlayerStat.rounds++;
        EnemyAvailable = wave.count;
        for (int i = 0; i < wave.count; i++)
        {
            SpawnEnemy(wave.enemy);
            yield return new WaitForSeconds(1f / wave.rate);
        }
        waveIndex++;
        
    }

    private void SpawnEnemy(GameObject enemy)
    {
        Instantiate(enemy, startPos.position, Quaternion.identity);
    }
}
