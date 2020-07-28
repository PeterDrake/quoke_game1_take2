using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Objective Outcome", menuName = "Dialogue/Outcomes/NothingToSay")]
public class NothingToSay : DialogueOutcome
{
    public string ObjectiveName;

    public string targetGameObject;

    public override void DoOutcome(ref NPC n)
    {
        GameObject.Find(targetGameObject).GetComponent<FlatFollow>().disappear();
    }
}
