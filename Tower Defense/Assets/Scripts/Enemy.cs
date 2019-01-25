using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] float speed = 10f;
    [SerializeField] float health = 100f;
    [SerializeField] int value = 50;

    public float Speed { get { return speed; } set { speed = value; } }
    public float Health { get { return health; } }

    public float StartSpeed { get; set; }

    private HealthBar healthBar;
   

    private void Start()
    {
        healthBar = GetComponent<HealthBar>();
        StartSpeed = speed;
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        StartCoroutine(healthBar.UpdateHealthBar(health));
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        PlayerStat.money += value;
        value = 0;
        WaveSpawner.EnemyAvailable--;
        Destroy(gameObject);
    }

    public void Slow(float slowRate)
    {
        speed = StartSpeed * (1f - slowRate);
    }
}
