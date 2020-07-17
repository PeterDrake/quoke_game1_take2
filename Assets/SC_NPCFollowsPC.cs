using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SC_NPCFollowsPC : MonoBehaviour
{
    //Transform that NPC has to follow
    public Transform transformToFollow;
    //NavMesh Agent variable
    NavMeshAgent agent;
    public GameObject Player;
    public GameObject NPC;
    int check = 0;
    private Animator animator;
    private bool walks;
    
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        animator.SetBool("isWalking", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log(Player.transform.position.x + " and " + NPC.transform.position.x);
            Debug.Log(Player.transform.position.z + " and " + NPC.transform.position.z);
        }
        //NPC.GetComponent<Animator>().Play("Walking");
        transform.LookAt(Player.transform);
        if (Mathf.Abs(Player.transform.position.x - NPC.transform.position.x) > 2.8  ||
            Mathf.Abs(Player.transform.position.z - NPC.transform.position.z) > 2.8)
        {
            Debug.Log("Walking");
            animator.SetBool("isWalking", true);
        }
        else
        {
            Debug.Log("Idle");
            animator.SetBool("isWalking", false);
        }
        agent.SetDestination(transformToFollow.position);
    }

}