using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Debug = UnityEngine.Debug;

[CreateAssetMenu(fileName = "New Objective Outcome", menuName = "Dialogue/Outcomes/ChangeBanner")]
public class DialogueChangeBanner : DialogueOutcome
{
    public string ObjectiveName;

    private InformationCanvas _banner;
    private string current;
    public string words;
    public bool Find;
    public bool Found;


    public override void DoOutcome(ref NPC n)
    {
        _banner = GameObject.Find("GUI").GetComponent<GuiDisplayer>().GetBanner();
        current = _banner.info.text;
        Debug.Log(current);

        //if words is to find somethig
        if (Find && words.Contains("Find"))
        {
            //if words to find something and current is finding things add to end
            if (current.Contains("Find"))
            {
                words = words.Replace("Find ", "");
                _banner.ChangeText(current + ", " + words);
            }
            //if current says a different task then change to find task
            else
            {
                _banner.ChangeText(words);
            }
        }

        //changes whole statement to words
        else if (Find)
        {
            _banner.ChangeText(words);
        }

        //deletes from statement or replace when all tasks complete
        else if (Found)
        {
            current = current.Replace(words, string.Empty);
            Debug.Log("NEW  = " + current);
            _banner.ChangeText(current);
            if (current == "Find ")
            {
                _banner.ChangeText("Talk to survivors");
            }
        }
    }
}
