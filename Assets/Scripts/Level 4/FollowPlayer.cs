using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowPlayer : MonoBehaviour
{
    //You may consider adding a rigid body to the zombie for accurate physics simulation
    private GameObject wayPoint;
    private Vector3 wayPointPos;
    public float offset = 5f;
    //This will be the zombie's speed. Adjust as necessary.
    private float speed = 2.0f;
    NavMeshAgent nav;
    Animator animator;
    GameObject Player;
    void Start()
    {
        //At the start of the game, the zombies will find the gameobject called wayPoint.
        wayPoint = GameObject.Find("wayPoint");
        nav = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        transform.LookAt(Player.transform);
        animator.SetBool("isWalking", true);
        wayPointPos = new Vector3(wayPoint.transform.position.x, transform.position.y, wayPoint.transform.position.z + offset);
        //Here, the zombie's will follow the waypoint.
        transform.position = Vector3.MoveTowards(transform.position, wayPointPos, Time.deltaTime);
        if (nav.remainingDistance < nav.stoppingDistance)
        {
            print("Stop walking");
            animator.SetBool("isWalking", false);
        }
    }

}
