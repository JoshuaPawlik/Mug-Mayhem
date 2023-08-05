using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestHealth : MonoBehaviour
{
    public HealthBar healthBar;

    private int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        StartCoroutine(DamageOverTime());
    }

    IEnumerator DamageOverTime()
    {
        while(true)
        {
            DealDamage(50);
            yield return new WaitForSeconds(2);
            HealDamage(20);
            yield return new WaitForSeconds(2);
        }
    }

    public void DealDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void HealDamage(int heal)
    {
        currentHealth += heal;
        if(currentHealth > maxHealth)
            currentHealth = maxHealth;

        healthBar.SetHealth(currentHealth);
    }
}
