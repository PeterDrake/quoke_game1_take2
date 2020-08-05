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

        if (distance < nav.stoppingDistance)
        {
            print("I GOT THERE");
            NPCanimator.SetBool("isWalking", false);
        }
        else
        {
            NPCanimator.SetBool("isWalking", true);
            print("NOT THERE YET");

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
