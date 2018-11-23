using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    [SerializeField] Color ableToBuildColor;
    [SerializeField] Color unableToBuildColor;
    [SerializeField] Vector3 positionOffset;

    private GameObject turret;
    private Renderer rend;
    private Color startColor;

    BuildManager buildManager;

    private void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManager = BuildManager.instance;
    }

    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.GetTurretToBuild())
            return;

        if (turret != null)
        {
            Debug.Log("Cant build turret here");
            return;
        }

        GameObject turretToBuild = buildManager.GetTurretToBuild();
        turret = Instantiate(turretToBuild, transform.position + positionOffset, Quaternion.identity);
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

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
