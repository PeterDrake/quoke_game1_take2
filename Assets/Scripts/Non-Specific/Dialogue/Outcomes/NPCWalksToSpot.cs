﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[CreateAssetMenu(fileName = "New Objective Outcome", menuName = "Dialogue/Outcomes/NPCWalksToSpot")]
public class NPCWalksToSpot : DialogueOutcome
{
    public string NPC;


    public override void DoOutcome(ref NPC n)
    {
        
        GameObject.Find(NPC + "Controller").GetComponent<NavMeshAgent>().enabled = true;
        GameObject.Find(NPC + "Controller").GetComponent<NPCWalking>().enabled = true;
        GameObject.Find(NPC + "Controller").GetComponent<NPCWalking>().TurnOffInteract();


        //GameObject.Find(NPC + "Controller").GetComponent<InteractWithObject>().enabled = false;
        //GameObject.Find(NPC + "Controller").GetComponent<SphereCollider>().enabled = false;
    }

}
