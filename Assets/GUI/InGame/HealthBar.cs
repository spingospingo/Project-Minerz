using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{

    private Slider slider;
    private int counter;

    public int MaxHealth = 1000;
    public Image Fill;  
    public Color MaxHealthColor = Color.green;
    public Color MinHealthColor = Color.red;

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
        counter = MaxHealth;            // counter will be used for testin, can be replaced with other variables
    }

    private void Start()
    {
        slider.wholeNumbers = true;        
        slider.minValue = 0f;
        slider.maxValue = MaxHealth;
        slider.value = MaxHealth;        // start with max health
    }

    private void Update()
    {
        UpdateHealthBar(counter);        // for the purpose of testing
        counter--;                        // health is artificially lowered

    }

    public void UpdateHealthBar(int val)
    {
        slider.value = val;
        Fill.color = Color.Lerp(MinHealthColor, MaxHealthColor, (float)val / MaxHealth);
    }
}