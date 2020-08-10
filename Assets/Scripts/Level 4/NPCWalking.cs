using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCWalking : MonoBehaviour
{
    public GameObject targetSpot;
    public GameObject NPC;
    private NavMeshAgent navMeshAgent;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = NPC.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetposition = targetSpot.transform.position;
        FleeFromTarget(targetposition);
    }

    private void FleeFromTarget(Vector3 target)
    {
        Vector3 destination = PositionToFleeTowards(target);
        HeadForDestination(destination);
    }

    private void HeadForDestination(Vector3 destinationPos)
    {
        navMeshAgent.SetDestination(destinationPos);
    }
    private Vector3 PositionToFleeTowards(Vector3 target)
    {
        Vector3 runToPosition = target + (transform.forward);
        return runToPosition;
    }
}
