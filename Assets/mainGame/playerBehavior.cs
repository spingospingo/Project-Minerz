using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class playerBehavior : MonoBehaviour
{
    private LayerMask navigable, interactable;

    private NavMeshAgent playerAgent;
    private Ray clickRay;
    private Camera cam;

    private int mat1Inv, mat2Inv, mat3Inv, mat4Inv, mat5Inv;
    public int Mat1Inv
    {
        get { return mat1Inv; }
        set { mat1Inv = value; }
    }

    public int Mat2Inv
    {
        get { return mat2Inv; }
        set { mat2Inv = value; }
    }

    public int Mat3Inv
    {
        get { return mat3Inv; }
        set { mat3Inv = value; }
    }

    public int Mat4Inv
    {
        get { return mat4Inv; }
        set { mat4Inv = value; }
    }

    public int Mat5Inv
    {
        get { return mat5Inv; }
        set { mat5Inv = value; }
    }

    private enum State
    {
        Idle,
        Moving,
        Mining,
        Breaking,
    }
    private State state;

    private bool isMining;

    private GameObject objectToInteractWith;

    void Start()
    {
        playerAgent = GetComponent<NavMeshAgent>();
        navigable = LayerMask.GetMask("Floor");
        interactable = LayerMask.GetMask("Interactable");
        state = State.Idle;
    }

    void Update()
    {
        switch (state)
        {
            case State.Idle:
                //standing still. useless? unsure
                break;
            case State.Moving:
                //moving, but not moving to an interactable
                break;
            case State.Mining:
                //to mine mineral nodes
                /* isMining checks if the player is currently "busy"
                 * doing mine() already. if this variable wasn't
                 * there, then a new mine() coroutine would start
                 * every frame. */
                if (!isMining && playerAgent.remainingDistance <= 1.25f
                    && playerAgent.remainingDistance != 0)
                {
                    //mine once
                    StartCoroutine(mine(1));
                }
                break;
            case State.Breaking:
                //to break rocks
                if (playerAgent.remainingDistance <= 1.25f
                    && playerAgent.remainingDistance != 0)
                {
                    //destroy rock after 0.25 sec
                    Destroy(objectToInteractWith, 0.25f);
                }
                break;
        }
    }

    public void controlPlayer(RaycastHit hitInfo)
    {
        NavMeshPath path = new NavMeshPath();

        if (hitInfo.collider.gameObject.tag == "Mineral")
        {
            //assign mineral to target object
            objectToInteractWith = hitInfo.collider.gameObject;

            //move to target and set mode to "mining"
            playerAgent.SetDestination(hitInfo.point);
            state = State.Mining;
            playerAgent.stoppingDistance = 1.25f;
        }
        else if (hitInfo.collider.gameObject.tag == "Rock")
        {
            objectToInteractWith = hitInfo.collider.gameObject;

            playerAgent.SetDestination(hitInfo.point);
            state = State.Breaking;
            playerAgent.stoppingDistance = 1.25f;
        }
        //if ray collides with navmesh...
        else
        {
            playerAgent.CalculatePath(hitInfo.point, path);
            //if player can move to the point...
            if (path.status == NavMeshPathStatus.PathComplete)
            {
                //...tell player to move to that point
                playerAgent.SetDestination(hitInfo.point);
                state = State.Moving;
                playerAgent.stoppingDistance = 0;
            }
        }
    }

    private IEnumerator mine(int amount)
    {
        //set isMining, a "busy" flag, as true
        isMining = true;
        //check what kind of mineral is being mined and fill corresponding inventory
        switch(objectToInteractWith.name)
        {
            case "material1(Clone)":
                mat1Inv += objectToInteractWith.GetComponent<mineralAttributes>().mine(amount);
                break;
            case "material2(Clone)":
                mat2Inv += objectToInteractWith.GetComponent<mineralAttributes>().mine(amount);
                break;
            case "material3(Clone)":
                mat3Inv += objectToInteractWith.GetComponent<mineralAttributes>().mine(amount);
                break;
            case "material4(Clone)":
                mat4Inv += objectToInteractWith.GetComponent<mineralAttributes>().mine(amount);
                break;
            case "material5(Clone)":
                mat5Inv += objectToInteractWith.GetComponent<mineralAttributes>().mine(amount);
                break;
        }
        //timer inbetween gathers. adjust for mining speed
        yield return new WaitForSeconds(1);
        //player is no longer busy mining
        isMining = false;
    }
}


