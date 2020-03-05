using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class dayHandler : MonoBehaviour
{
    private GameObject sun;
    private GameObject moon;

    private float timeInSeconds;

    private int dayLengthInSeconds = 120;
    public int DayLengthInSeconds
    {
        get { return dayLengthInSeconds; }
        set
        {
            if (value > 0 && value <= 240)
            {
                dayLengthInSeconds = value;
            }
            else
            {
                throw new Exception("dayLength out of range!" +
                    "(0-240 sec)");
            }
        }
    }

    private bool day = true;
    private int dayCount = 1;

    void Start()
    {
        sun = GameObject.Find("Sun");
        moon = GameObject.Find("Moon");
        sun.GetComponent<lightOrbit>().TimeScale = 18f;
        moon.GetComponent<lightOrbit>().TimeScale = 18f;
    }

    void Update()
    {
        timeInSeconds += Time.deltaTime;

        if (timeInSeconds >= dayLengthInSeconds)
        {
            if (day == true)
            {
                timeInSeconds = 0;
                Debug.Log("Night " + dayCount + " begins.");
                day = false;
            }
            else
            {
                timeInSeconds = 0;
                dayCount++;
                Debug.Log("Day " + dayCount + " begins.");
                day = true;
            }
        }
    }
}
