using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class worldGen : MonoBehaviour
{
    public GameObject bigRock;
    public GameObject smallRock;
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
        for (int z = zLim; z > 21; z-=2)
        {
            for (int x = xLim; x < -xLim + 1; x++)
            {
                int roll = Random.Range(1, 100);
            //if (roll <= 5)
            //{
            //    Vector3 spawnPos = new Vector3(x, 1, zLim - 1);
            //    //yield return new WaitForSeconds(1);
            //    Instantiate(bigRock, spawnPos, rotation);
            //    x+=2;
            //}
                if (roll >= 35)
                {
                    Vector3 spawnPos = new Vector3(x, 1, z);
                    //yield return new WaitForSeconds(1);
                    Instantiate(smallRock, spawnPos, rotation);
                    x++;
                }
            }
        }
    }
}
