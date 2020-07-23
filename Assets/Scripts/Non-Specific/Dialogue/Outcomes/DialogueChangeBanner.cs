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
        if (current.Contains("Find") == false && Find)
        {
            _banner.ChangeText("Find " + words);
        }
        else if (Find)
        {
            _banner.ChangeText(_banner + ", " + words);

        }
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
