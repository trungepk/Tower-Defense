using System;
using UnityEngine;

public class Turret : MonoBehaviour {

    [SerializeField] float range = 15f;
    [SerializeField] LayerMask checkLayer;
    [SerializeField] Transform partToRotate;
    [SerializeField] float turnSpeed = 10f;

    [SerializeField] Transform nearestTarget;
	void Start () {
		
	}
	
	void Update ()
    {
        DetectNearestEnemy();
        LockOnTarget();
    }

    private void DetectNearestEnemy()
    {
        Collider[] colliders = Physics.OverlapSphere(transform.position, range, checkLayer);
        Array.Sort(colliders, new DistanceComparer(transform));
        if (colliders.Length >= 1)
        {
            nearestTarget = colliders[0].transform;
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

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, range);
    }
}
