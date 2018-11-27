using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PriceUI : MonoBehaviour {

    [SerializeField] Text priceText;

    public enum Turret
    {
        standardTurret, missleLauncher
    }

    public Turret turret;

	void Start () {
      
	}
	
	
}
