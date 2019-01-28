using System;
using UnityEngine;

public class Turret : MonoBehaviour {
    [Header("Turret set-up")]
    [SerializeField] LayerMask enemyLayer;
    [SerializeField] Transform partToRotate;
    [SerializeField] Transform firePoint;

    [Header("General")]
    [SerializeField] float range = 15f;
    [SerializeField] float turnSpeed = 10f;

    [Header("Default bullet")]
    [SerializeField] float fireRate = 2f;
    [SerializeField] GameObject bulletPrefab;

    [Header("Use laser")]
    [SerializeField] bool useLaser;
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] float damageOverTime = 30f;
    [SerializeField] [Range(0, 1)] float slowRate = 0.5f;

    private float fireCoundown;
    private Transform nearestTarget;
    private Enemy target;
	
	void Update ()
    {
        DetectNearestEnemy();
        LockOnTarget();
        if (!nearestTarget)
        {
            if (useLaser && lineRenderer.enabled)
                lineRenderer.enabled = false;

            return;
        }

        if (useLaser)
            ShootLaser();
        else
            CountDownToShoot();
    }

    private void DetectNearestEnemy()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, range, enemyLayer);
        Array.Sort(colliders, new DistanceComparer(transform));
        if (colliders.Length >= 1)
        {
            nearestTarget = colliders[0].transform;
            target = nearestTarget.GetComponent<Enemy>();
        }
        else
        {
            nearestTarget = null;
        }
    }

    private void LockOnTarget()
    {
        if (nearestTarget)
        {
            Vector3 dir = nearestTarget.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
            partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
        }
    }

    private void ShootLaser()
    {
        if (!lineRenderer.enabled)
            lineRenderer.enabled = true;

        lineRenderer.SetPosition(0, firePoint.position);
        lineRenderer.SetPosition(1, nearestTarget.position);
        target.TakeDamage(damageOverTime * Time.deltaTime);
        target.Slow(slowRate);
    }

    private void CountDownToShoot()
    {
        if (fireCoundown <= 0 && nearestTarget)
        {
            Shoot();
            fireCoundown = 1f / fireRate;
        }
        fireCoundown -= Time.deltaTime;
    }

    private void Shoot()
    {
        GameObject bulletObj = Instantiate(bulletPrefab, firePoint.position, transform.rotation);
        Bullet bullet = bulletObj.GetComponent<Bullet>();
        if (bullet)
        {
            if (bullet.Speed < target.Speed)
                bullet.Speed = target.Speed + 5;

            bullet.Seek(nearestTarget);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
