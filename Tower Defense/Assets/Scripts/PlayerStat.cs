using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour {

    public static int money;
    [SerializeField] int startMoney = 100;

    private void Start()
    {
        money = startMoney;
    }

}
