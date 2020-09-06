using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider HealthSlider;

    public void SetHealth(int health)
    {
        HealthSlider.value = health;
    }

    public void SetMaxHealth(int maxHealth)
    {
        HealthSlider.maxValue = maxHealth;
        HealthSlider.value = maxHealth;
    }
}
