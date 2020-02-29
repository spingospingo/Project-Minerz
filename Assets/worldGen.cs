using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class worldGen : MonoBehaviour
{
    public GameObject rocks;
    private int xLim = -79;
    private int zLim = 79;
    private Quaternion rotation = Quaternion.identity;

    // Start is called before the first frame update
    void Start()
    {
        placeRocks();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void placeRocks()
    {
        for (int x = xLim; x < -xLim+1; x+=2)
        {
            Vector3 spawnPos = new Vector3(x, 1, zLim);
            //yield return new WaitForSeconds(1);
            Instantiate(rocks, spawnPos, rotation);
        }
    }
}
