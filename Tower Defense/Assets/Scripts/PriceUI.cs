using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PriceUI : MonoBehaviour {

    [SerializeField] Text priceText;
    [SerializeField] Shop shop;

    public enum TurretEnum
    {
        standardTurret, missleLauncher
    }

    public TurretEnum turret;

	void Start () {
        
        var turretPrice = GetTurretPrice(turret);
        priceText.text = "$" + turretPrice.ToString();
	}
	
    private int GetTurretPrice(TurretEnum turret)
    {
        if(turret == TurretEnum.standardTurret)
        {
            return shop.standardTurret.cost;
        }else if(turret == TurretEnum.missleLauncher)
        {
            return shop.missleLauncher.cost;
        }
        return -1;
    }
	
}
