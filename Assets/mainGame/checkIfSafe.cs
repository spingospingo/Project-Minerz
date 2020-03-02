using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class checkIfSafe : MonoBehaviour
{
    private Vector3 origin = Vector3.zero;
    private NavMeshAgent player;

    void Start()
    {
        player = GetComponent<NavMeshAgent>();
        StartCoroutine(safeCheck());
    }

    IEnumerator safeCheck()
    {
        while(true)
        {
            //instantiate path object
            NavMeshPath path = new NavMeshPath();
            yield return new WaitForSeconds(1);
            //create path from player to enemy spawner
            player.CalculatePath(origin, path);
            //if complete path cannot be made...
            if (path.status == NavMeshPathStatus.PathPartial)
            {
                //Debug.Log("SAFE");
            }
            //if complete path CAN be made...
            else
            {
                //Debug.Log("NOT SAFE");
            }
        }
    }
}
