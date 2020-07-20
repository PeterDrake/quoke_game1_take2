using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Objective Outcome", menuName = "Dialogue/Outcomes/ChangeBanner")]
public class DialogueChangeBanner : DialogueOutcome
{
    public string ObjectiveName;

    public InformationCanvas _canvas;
    public string words;


    public override void DoOutcome(ref NPC n)
    {
        _canvas.ChangeText(words);
    }
}
