using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public HpHandler hpHandler;
    public int maxHealth = 100;
    public int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        GameDB.towerhp = currentHealth;
        UpdateHealthBar();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            TakeDamage(20);
        }
    }

    public int TakeDamage(int damage)
    {
        int previousHealth = currentHealth;
        currentHealth = Mathf.Max(currentHealth - damage, 0);
        
        UpdateHealthBar();
        return previousHealth - currentHealth;
    }

    private void UpdateHealthBar()
    {
        float hpPercentage = (float)currentHealth / maxHealth;
        hpHandler.SetHp(hpPercentage);
    }
}