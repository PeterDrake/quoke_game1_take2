using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCFollowing : MonoBehaviour
{
    public GameObject Leader;
    public GameObject NPC;
    private NavMeshAgent nav;
    private Animator NPCanimator;
    private Animator Leaderanimator;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        NPCanimator = NPC.GetComponent<Animator>();
        Leaderanimator = Leader.GetComponent<Animator>();
        HeadForDestination();
    }

    private void Update()
    {

        float distance = Vector3.Distance(Leader.transform.position, transform.position);
        if (distance > 10)
        {
            NPCanimator.SetBool("isWalking", false);
            NPCanimator.SetBool("isRunning", true);
            nav.speed = 6;
        }
        if (distance <= 10)
        {
            NPCanimator.SetBool("isWalking", true);
            NPCanimator.SetBool("isRunning", false);
            nav.speed = 3;
        }
        if (distance < nav.stoppingDistance)
        {
            NPCanimator.SetBool("isWalking", false);
            transform.LookAt(new Vector3(Leader.transform.position.x, transform.position.y, Leader.transform.position.z));

        }
        else
        {
            NPCanimator.SetBool("isWalking", true);

        }
        HeadForDestination();

    }

    private void HeadForDestination()
    {
        Vector3 destination = Leader.transform.position;
        //transform.LookAt(new Vector3(Leader.transform.position.x, transform.position.y, Leader.transform.position.z));
        nav.SetDestination(destination);
    }



}
