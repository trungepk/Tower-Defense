using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] float speed = 10f;
    [SerializeField] float health = 100f;
    [SerializeField] int value = 50;

    public float Speed { get { return speed; } set { speed = value; } }

    public float StartSpeed { get; set; }

    private void Start()
    {
        StartSpeed = speed;
    }

    public void TakeDamage(float dmg)
    {
        health -= dmg;
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        PlayerStat.money += value;
        Destroy(gameObject);
    }

    public void Slow(float slowRate)
    {
        speed = StartSpeed * (1f - slowRate);
    }
}
