using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Node : MonoBehaviour {

    [SerializeField] Color ableToBuildColor;
    [SerializeField] Color unableToBuildColor;
    [SerializeField] Vector3 positionOffset;

    private GameObject turret;
    private Renderer rend;
    private Color startColor;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }

    private void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("Cant build turret here");
            return;
        }

        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = Instantiate(turretToBuild, transform.position + positionOffset, Quaternion.identity);
    }

    private void OnMouseEnter()
    {
        if (turret != null)
        {
            rend.material.color = unableToBuildColor;
            return;
        }
        rend.material.color = ableToBuildColor;
    }

    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
}
