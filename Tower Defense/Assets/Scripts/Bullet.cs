using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField] LayerMask targetLayer;
    [SerializeField] int damage = 50;
    [SerializeField] float speed = 70f;
    [SerializeField] float explosionRadius;
    
    private Transform target;

    public float Speed { get { return speed; } set { speed = value; } }

    public void Seek(Transform target)
    {
        this.target = target;
    }

    private void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        var distanceThisFrame = Speed * Time.deltaTime;
        if (dir.magnitude <= distanceThisFrame)
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
        transform.LookAt(target);
    }

    private void HitTarget()
    {
        if (explosionRadius > 0f)
        {
            Explosion();
        }
        else
        {
            Damage(target);
        }
        Destroy(gameObject);
    }

    private void Explosion()
    {
        var colliders = Physics.OverlapSphere(transform.position, explosionRadius, targetLayer);
        foreach(var collider in colliders)
        {
            Damage(collider.transform);
        }
    }

    private void Damage(Transform target)
    {
        Enemy e = target.GetComponent<Enemy>();
        if (e)
        {
            e.TakeDamage(damage);
        }
    }

    private void OnDrawGizmosSelected ()
    {
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
