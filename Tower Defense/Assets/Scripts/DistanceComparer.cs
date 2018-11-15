using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DistanceComparer : IComparer
{
    private Transform turret;

    public DistanceComparer(Transform turret)
    {
        this.turret = turret;
    }

    public int Compare(object x, object y)
    {
        Collider xCollider = x as Collider;
        Collider yCollider = y as Collider;

        Vector3 offset = xCollider.transform.position - turret.position;
        var xDistance = offset.sqrMagnitude;

        offset = yCollider.transform.position - turret.position;
        var yDistance = offset.sqrMagnitude;

        return xDistance.CompareTo(yDistance);
    }
}
