using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFollowsPC : MonoBehaviour
{
    public GameObject Player;
    public float TargetDistance;
    private float AllowedDistance = 3;
    public GameObject NPC;
    private float FollowSpeed;
    private RaycastHit Shot;

    
    void Update()
    {
        transform.LookAt(Player.transform);
        if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out Shot))
        {
            TargetDistance = Shot.distance;
            if (TargetDistance >= AllowedDistance)
            {
                FollowSpeed = 1.1f;
                NPC.GetComponent<Animator>().Play("Move");
                transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, FollowSpeed);
            }
            else
            {
                FollowSpeed = 0;
                NPC.GetComponent<Animator>().Play("walking");
            }
        }
    }

}
