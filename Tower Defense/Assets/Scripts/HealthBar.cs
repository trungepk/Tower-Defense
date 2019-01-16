using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour {

    [SerializeField] GameObject healthBarCanvas;
    [SerializeField] Image healthBar;
    [SerializeField] Color halfLifeBarColor;
    [SerializeField] Color nearDeadBarColor;
    private Enemy enemy;
    private float startHP;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        startHP = enemy.Health;
    }

    public IEnumerator UpdateHealthBar(float currentHP)
    {
        healthBarCanvas.SetActive(true);
        healthBar.fillAmount = currentHP / startHP;
        ChangeColor();
        yield return new WaitForSeconds(1f);
        if (currentHP == enemy.Health)
        {
            healthBarCanvas.SetActive(false);
        }
    }

    private void ChangeColor()
    {
        if (healthBar.fillAmount <= 0.5f && healthBar.fillAmount >= 0.2f)
        {
            healthBar.color = halfLifeBarColor;
        }
        else if (healthBar.fillAmount < 0.2f)
        {
            healthBar.color = nearDeadBarColor;
        }
    }
}
