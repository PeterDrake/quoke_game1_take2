using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "New Objective Outcome", menuName = "Dialogue/Outcomes/FollowZelda")]
public class FollowZelda : DialogueOutcome
{
    public string NPCFollower;

    public override void DoOutcome(ref NPC n)
    {
        GameObject.Find(NPCFollower + "Controller").GetComponent<NavMeshAgent>().enabled = true;
        GameObject.Find(NPCFollower + "Controller").GetComponent<NPCFollowing>().enabled = true;
        GameObject.Find(NPCFollower + "Controller").GetComponent<InteractWithObject>().enabled = false;
        GameObject.Find(NPCFollower + "Controller").GetComponent<SphereCollider>().enabled = false;
    }
}
