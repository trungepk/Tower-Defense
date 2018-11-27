using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildManager : MonoBehaviour {

    public static BuildManager instance;
    public GameObject standardTurretPrefab;
    public GameObject missleLauncherPrefab;

    private TurretBlueprint turretToBuild;

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

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
}
