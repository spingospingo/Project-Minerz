using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAI : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent enemy;
    private GameObject player;
    private Vector3 target;
    private int health = 100; //placeholder value

    void Start()
    {
        enemy = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.Find("Player");
    }

    void FixedUpdate()
    {
        target = new Vector3(player.transform.position.x,
            player.transform.position.y,
            player.transform.position.z);
        enemy.SetDestination(target);

        if (health <= 0)
        {
            Destroy(gameObject, 1);
            Debug.Log("blargh im dead");
        }
    }
}
