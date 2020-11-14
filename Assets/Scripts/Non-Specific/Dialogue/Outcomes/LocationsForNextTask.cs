using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Objective Outcome", menuName = "Dialogue/Outcomes/LocationsForNextTask")]
public class LocationsForNextTask : DialogueOutcome
{
    public string hint;
    public GameObject taskCompleted;

    private HintController controller;

    public override void DoOutcome(ref NPC n)
    {
        controller = GameObject.Find(hint).GetComponent<HintController>();
        if(taskCompleted != null)
        {
            controller.AllTaskCompleted(taskCompleted);
        }

        controller.NextTask();
    }
}
