﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider slider;
    private int counter;

    public int Health = 1000;
    public Image Fill;
    public Color MaxHealthColor = Color.green;
    public Color MinHealthColor = Color.red;
    private buildingAttributes Attributes;

    private void Awake()
    {
        slider = gameObject.GetComponent<Slider>();
        Attributes = GameObject.Find("buildingPlaceHolder").GetComponent<buildingAttributes>();
        counter = Health;           
    }

    private void Start()
    {
        slider.wholeNumbers = true;
        slider.minValue = 0f;
        slider.maxValue = 1000f;
        slider.value = Health;        
    }

    private void Update()
    {
        Health = Attributes.Health;
        slider.value = Health;                                                                   
        Fill.color = Color.Lerp(MinHealthColor, MaxHealthColor, slider.value / slider.maxValue);
    }
}
   
        
       
   