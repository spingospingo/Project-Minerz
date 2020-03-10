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
    }
    private State state;

    private bool isMining;
    private bool isChecking;

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

                break;
            case State.Moving:

                break;
            case State.Mining:
                if (!isMining && playerAgent.remainingDistance <= 1.5f
                    && playerAgent.remainingDistance != 0)
                {
                    StartCoroutine(mine(1));
                }
                break;
        }
    }

    public void controlPlayer(RaycastHit hitInfo)
    {
        NavMeshPath path = new NavMeshPath();

        //if ray collides with an interactable object...
        if (hitInfo.collider.gameObject.tag == "Mineral"
            || hitInfo.collider.gameObject.tag == "Rock")
        {
            objectToInteractWith = hitInfo.collider.gameObject;

            playerAgent.SetDestination(hitInfo.point);
            state = State.Mining;
            playerAgent.stoppingDistance = 1.5f;
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
        isMining = true;
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
        yield return new WaitForSeconds(1);
        isMining = false;
    }
}


