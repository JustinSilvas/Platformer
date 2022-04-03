using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Text lifeCountText; //Calls life count text
    public Slider slider; //Calls health bar slider

    public void SetMaxHealth(int health) //changes health bar slider max health
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(int health) //changes health bar slider health
    {
        slider.value = health;
    }

    public void SetLifeCount(int lifeCount) //changes life count
    {
        lifeCountText.text = lifeCount.ToString();
    }
}
