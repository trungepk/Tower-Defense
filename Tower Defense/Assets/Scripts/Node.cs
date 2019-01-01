using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour {

    [SerializeField] Color ableToBuildColor;
    [SerializeField] Color unableToBuildColor;
    [SerializeField] Vector3 positionOffset;

    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBlueprint turretBlueprint;
    [HideInInspector]
    public bool isUpgraded;

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

        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }

        if (!buildManager.CanBuild)
            return;

        BuildTurret(buildManager.GetTurretToBuild());
    }

    private void BuildTurret(TurretBlueprint blueprint)
    {
        if (PlayerStat.money < blueprint.cost)
        {
            return;
        }
        PlayerStat.money -= blueprint.cost;
        GameObject turret = Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
        this.turret = turret;
        turretBlueprint = blueprint;
    }

    public void UpgradeTurret()
    {
        if (PlayerStat.money < turretBlueprint.upgradeCost)
        {
            return;
        }
        PlayerStat.money -= turretBlueprint.upgradeCost;

        Destroy(this.turret); //get rid of old turret

        GameObject turret = Instantiate(turretBlueprint.upgradePrefab, GetBuildPosition(), Quaternion.identity);
        this.turret = turret;

        isUpgraded = true;
    }

    public void SellTurret()
    {
        PlayerStat.money += turretBlueprint.GetSellAmount();
        Destroy(turret);
        isUpgraded = false;
        turretBlueprint = null;
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (!buildManager.CanBuild)
            return;

        if (turret != null || !buildManager.HasMoney)
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

    public Vector3 GetBuildPosition()
    {
        return transform.position + positionOffset;
    }
}
