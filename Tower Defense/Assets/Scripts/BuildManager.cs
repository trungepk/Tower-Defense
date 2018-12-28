﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;
    public GameObject standardTurretPrefab;
    public GameObject missleLauncherPrefab;
    public NodeUI nodeUI;

    private TurretBlueprint turretToBuild;
    private Node selectedNode;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStat.money >= turretToBuild.cost; } }

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }else if (instance != this)
        {
            instance = this;
        }
    }

    public void SelectNode(Node node)
    {
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;
        nodeUI.SetTarget(node);

    }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        DeselectNode();
    }

    public void DeselectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public void BuildTurretOn(Node node)
    {
        if (PlayerStat.money < turretToBuild.cost)
        {
            Debug.Log("Not enough money");
            return;
        }
        PlayerStat.money -= turretToBuild.cost;
        GameObject turret = Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
        node.turret = turret;
        Debug.Log("Money left: " + PlayerStat.money);
    }
}
