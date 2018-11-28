using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour {

    public static int money;
    [SerializeField] int startMoney = 100;

    public static int lives;
    [SerializeField] int startLives = 5;

    private void Start()
    {
        money = startMoney;
        lives = startLives;
    }

}
