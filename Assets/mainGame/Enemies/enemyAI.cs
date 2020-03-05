using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class enemyAI : MonoBehaviour
{
    private NavMeshAgent enemyAgent;
    private GameObject player;
    private Vector3 target;
    private NavMeshPath path;

    void Start()
    {
        enemyAgent = GetComponent<NavMeshAgent>();
        //NOTE: change player once multiple players exist
        player = GameObject.Find("Player");
        path = new NavMeshPath();
    }

    void FixedUpdate()
    {
        focusTarget();
    }

    private void focusTarget()
    {
        //convert player location to Vector3
        target = new Vector3(player.transform.position.x,
            player.transform.position.y,
            player.transform.position.z);
        //create path towards player
        enemyAgent.CalculatePath(target, path);
        //if enemy can path to player...
        if (path.status == NavMeshPathStatus.PathComplete)
        {
            //...go to player
            enemyAgent.SetDestination(target);
        }
    }
}
