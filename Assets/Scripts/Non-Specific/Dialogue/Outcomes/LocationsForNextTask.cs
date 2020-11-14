using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Objective Outcome", menuName = "Dialogue/Outcomes/LocationsForNextTask")]
public class LocationsForNextTask : DialogueOutcome
{
    public GameObject taskCompleted;

    public override void DoOutcome(ref NPC n)
    {
        HintController controller = GameObject.Find("LocationsOfInterest").GetComponent<HintController>();

        controller.NextTask();
    }
}
