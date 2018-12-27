using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour {

    public static int money;
    [SerializeField] int startMoney = 100;

    public static int lives;
    [SerializeField] int startLives = 5;

    public static int rounds;

    private void Start()
    {
        money = startMoney;
        lives = startLives;
        rounds = 0;
    }

}
