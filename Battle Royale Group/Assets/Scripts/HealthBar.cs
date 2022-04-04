using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider healthSlider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetHealth(int health)
    {
        // Adjust the health bar according to current health
        healthSlider.value = health;
    }

    public void SetMaxHealth(int health)
    {
        // Set the max health 
        healthSlider.maxValue = health;
        // Set the health bar to max health
        healthSlider.value = health;
    }
}
