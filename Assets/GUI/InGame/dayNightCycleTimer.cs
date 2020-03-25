using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dayNightCycleTimer : MonoBehaviour
{
    private RectTransform rectTransform;
    private float cycleTimeScale; 

    void Start()
    {
        //Get rectungular transformation component 
        rectTransform = GetComponent<RectTransform>();

        //Get TimeScale variable from GameObject Sun, should make timer scale with different day lengths
        cycleTimeScale = GameObject.Find("Sun").GetComponent<lightOrbit>().TimeScale;
    }

   
    void Update()
    {
        //Rotate transformation component about z axis at "cycleTimeScale" units per second
        rectTransform.Rotate(new Vector3(0, 0, cycleTimeScale * Time.deltaTime));
    }
}
