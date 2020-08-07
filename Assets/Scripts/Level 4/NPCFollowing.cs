using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCFollowing : MonoBehaviour
{
    public float runAwayDistance = 10;
    public GameObject targetGO;
    public GameObject NPC;
    private NavMeshAgent navMeshAgent;
    private Animator animator;
    private float last;
    public bool shelter;
    private int check = 20;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = NPC.GetComponent<Animator>();
        shelter = false;
        last = 0f;
    }
    private void Update()
    {
        if (shelter)
        {
            GoToShelter();
        }


        else
        {
            Vector3 targetPosition = targetGO.transform.position;
            float distanceToTarget = Vector3.Distance(transform.position, targetPosition);

            if (distanceToTarget > runAwayDistance - 1 && distanceToTarget < runAwayDistance + 1 || last == distanceToTarget)
            {
                print(distanceToTarget + "im here");
                animator.SetBool("isRunning", false);
                animator.SetBool("isWalking", false);
            }

            else if (distanceToTarget < runAwayDistance - 1)
            {
                print("wayyyy close");
                animator.SetBool("isRunning", false);
                animator.SetBool("isWalking", true);
            }
            else
            {
                animator.SetBool("isRunning", true);
                animator.SetBool("isWalking", false);
                print("running" + distanceToTarget);
            }
            FleeFromTarget(targetPosition);
            last = distanceToTarget;
        }
    }

    private void FleeFromTarget(Vector3 targetPosition)
    {
        Vector3 destination = PositionToFleeTowards(targetPosition);
        HeadForDestintation(destination);
    }

    private void HeadForDestintation(Vector3 destinationPosition)
    {
        navMeshAgent.SetDestination(destinationPosition);
        
    }

    private Vector3 PositionToFleeTowards(Vector3 targetPosition)
    {
        transform.rotation = Quaternion.LookRotation(new Vector3(transform.position.x - targetPosition.x, targetPosition.y, transform.position.z - targetPosition.z));
        Vector3 runToPosition = targetPosition + (transform.forward * runAwayDistance);
        return runToPosition;
    }

    public void GoToShelter()
    {
        shelter = true;
        print("GOING TO SHELTER");
        Vector3 destination = GameObject.Find("SchoolDoorStep").transform.position;
        float distance = Vector3.Distance(destination, transform.position);
        runAwayDistance = 2f;
        navMeshAgent.speed = 3f;
        animator.SetBool("isWalking", true);
        animator.SetBool("isRunning", false);

        if (check == 0)
        {
            print("in the shelter I MAAADDDEE IT ");
            GameObject.Find("Mo").SetActive(false);
            GameObject.Find("MoPointer").SetActive(false);
            GameObject.Find("MoAlert").SetActive(false);
            this.enabled = false;
        }

        if (distance <= 2.5)
        {
            animator.SetBool("isWalking", false);
            check--;
        }

        FleeFromTarget(destination);
    }


}
