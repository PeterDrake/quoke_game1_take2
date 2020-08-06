using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCFollowing : MonoBehaviour
{
    //public GameObject Leader;
    //public GameObject NPC;
    //private NavMeshAgent nav;
    //private Animator NPCanimator;
    //private Animator Leaderanimator;
    //public bool shelter;
    //private bool inShelter;
    //private float runAwayDistance;

    //// Start is called before the first frame update
    //void Start()
    //{
    //    nav = GetComponent<NavMeshAgent>();
    //    NPCanimator = NPC.GetComponent<Animator>();
    //    Leaderanimator = Leader.GetComponent<Animator>();
    //    shelter = false;
    //    inShelter = false;
    //    runAwayDistance = 5f;
        
    //}


    public float runAwayDistance = 10;
    public GameObject targetGO;
    public GameObject NPC;
    private NavMeshAgent navMeshAgent;
    private Animator animator;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = NPC.GetComponent<Animator>();
    }
    private void Update()
    {
        Vector3 targetPosition = targetGO.transform.position;
        float distanceToTarget = Vector3.Distance(transform.position, targetPosition);

        FleeFromTarget(targetPosition);
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
        transform.rotation = Quaternion.LookRotation(transform.position - targetPosition);
        Vector3 runToPosition = targetPosition + (transform.forward * runAwayDistance);
        return runToPosition;
    }
}


//void Update()
//{

//if (shelter)
//{
//    print("GOING TO SHELTER");
//    Vector3 destination = GameObject.Find("SchoolDoorStep").transform.position;
//    float distance = Vector3.Distance(destination, transform.position);
//    nav.stoppingDistance = 2f;
//    NPCanimator.SetBool("isWalking", true);


//    if (distance <= nav.stoppingDistance)
//    {
//        print("in the shelter I MAAADDDEE IT ");
//        GameObject.Find("Mo").SetActive(false);
//        GameObject.Find("MoPointer").SetActive(false);
//        GameObject.Find("MoAlert").SetActive(false);
//        this.enabled = false;
//    }

//    HeadForDestination(destination);
//}

//else
//{
//    print("FOLLOWING ZELDA");
//    float distance = Vector3.Distance(Leader.transform.position, transform.position);
//    Vector3 destination = Leader.transform.position + (transform.forward *  runAwayDistance);
//if (distance > 10)
//{
//    print("TOOO FARRRR!!! ILL RUN");
//    NPCanimator.SetBool("isWalking", false);
//    NPCanimator.SetBool("isRunning", true);
//    nav.speed = 6;
//}
//if (distance <= 10)
//{
//    print("ILL WALK THERE DONT WORRY");
//    NPCanimator.SetBool("isWalking", true);
//    NPCanimator.SetBool("isRunning", false);
//    nav.speed = 3;
//}
//if (distance <= nav.stoppingDistance)
//{
//    NPCanimator.SetBool("isWalking", false);
//}
//else
//{
//    NPCanimator.SetBool("isWalking", true);

//}

//HeadForDestination(destination);
//        }
//    }

//    private void HeadForDestination(Vector3 destination)
//    {
//        nav.SetDestination(destination);
//    }



//}
