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
    public Item ItemToFind;
    private string cutwords;
    public bool Find;
    private bool find;
    public bool Found;



    public override void DoOutcome(ref NPC n)
    {
        find = Find;

        _banner = GameObject.Find("GUI").GetComponent<GuiDisplayer>().GetBanner();
        current = _banner.info.text;

       //Doesnt repeat or change if already have item
        if (!current.Contains(words) && !current.Contains(cutwords))
        {
            if (Systems.Inventory.HasItem(ItemToFind, 1))
            {
                Debug.Log("ALREADU HAVE THAT");
                find = false;
            }
            //if words is to find somethig
            if (find)
            {
                Debug.Log("FIND");
                if (words.Contains("Find"))
                    {
                    //if words to find something and current is finding things add to end
                    if (current.Contains("Find"))
                    {
                        cutwords = words.Replace("Find ", "");
                        current = current.Replace(", and ", ", ");
                        _banner.ChangeText(current + ", and " + cutwords);
                    }

                    //if current says a different task then change to find task
                    else
                    {
                        _banner.ChangeText(words);
                    }
                }
                else
                {
                    _banner.ChangeText(words);
                }
            }

        }

        //deletes from statement or replace when all tasks complete
        if (Found)
        {
            current = current.Replace(", and " + words, "");
            current = current.Replace(", " + words, "");
            current = current.Replace(words + ",", "");
            current = current.Replace(words, "");
            Debug.Log("NEW  = " + current);
            _banner.ChangeText(current);
            Debug.Log("FOUND");
            if (Systems.Inventory.HasItem(Resources.Load<Item>("items/CleanMustardWater"), 1)
                    && Systems.Inventory.HasItem(Resources.Load<Item>("items/Shovel"), 1)
                    && Systems.Inventory.HasItem(Resources.Load<Item>("items/Rope"), 1))
            {
                _banner.ChangeText("Find Frank's backyard");
            }
            else if (current == "Find")
            {
              _banner.ChangeText("Talk to survivors");
          
            }
        }
    }
}
