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
    public bool shelter;
    private bool inShelter;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        NPCanimator = NPC.GetComponent<Animator>();
        Leaderanimator = Leader.GetComponent<Animator>();
        shelter = false;
        inShelter = false;
    }

    private void Update()
    {
        if (shelter)
        {
            print("GOING TO SHELTER");
            Vector3 destination = GameObject.Find("SchoolDoorStep").transform.position;
            float distance = Vector3.Distance(destination, transform.position);
            nav.stoppingDistance = 2f;
            NPCanimator.SetBool("isWalking", true);


            if (distance <= nav.stoppingDistance)
            {
                print("in the shelter I MAAADDDEE IT ");
                GameObject.Find("Mo").SetActive(false);
                GameObject.Find("MoPointer").SetActive(false);
                GameObject.Find("MoAlert").SetActive(false);
                this.enabled = false;
            }

            HeadForDestination(destination);
        }

        else
        {
            print("FOLLOWING ZELDA");
            float distance = Vector3.Distance(Leader.transform.position, transform.position);
            Vector3 destination = Leader.transform.position;
            if (distance > 10)
            {
                print("TOOO FARRRR!!! ILL RUN");
                NPCanimator.SetBool("isWalking", false);
                NPCanimator.SetBool("isRunning", true);
                nav.speed = 8;
            }
            if (distance <= 10)
            {
                print("ILL WALK THERE DONT WORRY");
                NPCanimator.SetBool("isWalking", true);
                NPCanimator.SetBool("isRunning", false);
                nav.speed = 4;
            }
            if (distance <= nav.stoppingDistance)
            {
                NPCanimator.SetBool("isWalking", false);
            }
            transform.LookAt(new Vector3(Leader.transform.position.x, transform.position.y, Leader.transform.position.z));
            HeadForDestination(destination);
        }
    }

    private void HeadForDestination(Vector3 destination)
    {
        nav.SetDestination(destination);
    }



}
