using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Objective Outcome", menuName = "Dialogue/Outcomes/ChangeBanner")]
public class DialogueChangeBanner : DialogueOutcome
{
    public string ObjectiveName;

    private InformationCanvas _banner;
    public string words;


    public override void DoOutcome(ref NPC n)
    {
        _banner = GameObject.Find("GUI").GetComponent<GuiDisplayer>().GetBanner();
        _banner.ChangeText(words);
    }
}
