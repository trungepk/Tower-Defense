﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : MonoBehaviour {

    [SerializeField] Text moneyText;

 	void Update () {
        moneyText.text = "$" + PlayerStat.money.ToString();	
	}
}
