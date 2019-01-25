using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyMovement : MonoBehaviour {
    private Transform target;
    private int waypointIndex;
    private Enemy enemy;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        target = Waypoint.points[0];
    }

    private void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * enemy.Speed * Time.deltaTime, Space.World);
        if (Vector3.Distance(transform.position, target.position) <= 0.4f)
        {
            GetNextWaypoint();
        }
        enemy.Speed = enemy.StartSpeed;
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
        WaveSpawner.EnemyAvailable--;
        Destroy(gameObject);
    }
}
