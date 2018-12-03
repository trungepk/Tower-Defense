using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    [SerializeField] float speed = 10f;
    [SerializeField] float health = 100f;
    [SerializeField] int value = 50;

    private Transform target;
    private int waypointIndex;

    private void Start()
    {
        target = Waypoint.points[0];
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, target.position) <= 0.4f) 
        {
            GetNextWaypoint();
        }
    }

    private void GetNextWaypoint()
    {
        if (waypointIndex >= Waypoint.points.Length - 1)
        {
            EndPoint();
            return;
        }
        waypointIndex++;
        target = Waypoint.points[waypointIndex];
    }

    private void EndPoint()
    {
        PlayerStat.lives--;
        Destroy(gameObject);
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
}
