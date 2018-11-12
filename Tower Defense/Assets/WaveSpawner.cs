using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveSpawner : MonoBehaviour {

    [SerializeField] Transform enemyPrefab;
    [SerializeField] Transform startPos;
    [SerializeField] float timeBetweenWaves = 5f;
    [SerializeField] float countdown = 2f;
    [SerializeField] float timeBetweenEnemies = 0.5f;
    [SerializeField] Text waveCountdownText;

    private int waveIndex;

    private void Update()
    {
        if (countdown <= 0)
        {
            StartCoroutine(SpawnWave());
            countdown = timeBetweenWaves;
        }
        countdown -= Time.deltaTime;
        waveCountdownText.text = Mathf.Round(countdown).ToString();
    }

    IEnumerator SpawnWave()
    {
        waveIndex++;
        for (int i = 0; i < waveIndex; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(timeBetweenEnemies);
        }
    }

    private void SpawnEnemy()
    {
        Instantiate(enemyPrefab, startPos.position, Quaternion.identity);
    }
}
