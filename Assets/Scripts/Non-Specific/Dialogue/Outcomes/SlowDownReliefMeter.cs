using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New GameObject Addition", menuName = "Dialogue/Outcomes/SlowDownReliefMeter")]
public class SlowDownReliefMeter : DialogueOutcome
{
    public override void DoOutcome(ref NPC n)
    {
        Systems.Status.SlowDownWarmthLossMore();
    }
}
