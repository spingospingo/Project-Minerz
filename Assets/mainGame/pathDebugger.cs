using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class pathDebugger : MonoBehaviour
{
    private LineRenderer line;
    private NavMeshAgent player;

    // Start is called before the first frame update
    void Start()
    {
        line = GetComponent<LineRenderer>();
        player = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.hasPath)
        {
            line.positionCount = player.path.corners.Length;
            line.SetPositions(player.path.corners);
            line.enabled = true;
        }
        else
        {
            line.enabled = false;
        }
    }
}
