using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    [SerializeField] Slider healthBar;

    public void GetMaxHealth()
    {
        healthBar.value = 1;
    }
    public void UpdateHealth(float currentHealth, float maxHealth)
    {
        healthBar.value = currentHealth/maxHealth;
    }
}
