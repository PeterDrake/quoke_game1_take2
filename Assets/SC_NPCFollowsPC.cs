using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SC_NPCFollowsPC : MonoBehaviour
{
    //Transform that NPC has to follow
    public Transform transformToFollow;
    public GameObject Player;
    //NavMesh Agent variable
    NavMeshAgent agent;
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        //NavMeshAgent.Warp
    }

    // Update is called once per frame
    void Update()
    {
        //if (Mathf.Abs(Player.transform.position.x - agent.transform.position.x) > 5 || Mathf.Abs(Player.transform.position.z - agent.transform.position.z) > 5)
        //{
            //agent.SetDestination(new Vector3(transformToFollow.position.x - 1, transformToFollow.position.y, transformToFollow.position.z-1));
        //}

        //agent.SetDestination(transformToFollow.position);

        agent.SetDestination(new Vector3(transformToFollow.position.x - 1, transformToFollow.position.y, transformToFollow.position.z-1));
        
        /*else
        {
            agent.GetComponent<Animator>().Play("idle");
        }*/
    }

}
