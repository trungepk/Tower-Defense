using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    [SerializeField] Image healthBar;
    private Enemy enemy;
    private float startHP;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        startHP = enemy.Health;
    }

    public void UpdateHealthBar(float currentHP)
    {
        healthBar.fillAmount = currentHP / startHP;
    }
}
