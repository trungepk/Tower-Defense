using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField] LayerMask targetLayer;
    [SerializeField] float speed = 70f;
    [SerializeField] float explosionRadius;
    
    private Transform target;

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
        var distanceThisFrame = speed * Time.deltaTime;
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
        Destroy(target.gameObject);
    }

    private void OnDrawGizmosSelected ()
    {
        Gizmos.DrawWireSphere(transform.position, explosionRadius);
    }
}
