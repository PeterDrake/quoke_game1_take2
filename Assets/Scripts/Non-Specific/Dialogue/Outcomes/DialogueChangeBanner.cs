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
    private string shorten;
    public bool Find;
    private bool find;
    public bool Found;


    public override void DoOutcome(ref NPC n)
    {
        find = Find;

        _banner = GameObject.Find("GUI").GetComponent<GuiDisplayer>().GetBanner();
        current = _banner.info.text;
        Debug.Log(current);
        shorten = words.Replace("Find ", "");

        //no repeats
        if (current.Contains(shorten) || Systems.Inventory.HasItem(ItemToFind,1))
        {
            Debug.Log("Already have");
            find = false;
        }


        //for any find task
        if (find)
        {
            Debug.Log("NO REPEATS");
            // Find task
            if (words.Contains("Find") && current.Contains("Find"))
            {
                Debug.Log("ADD" + shorten);
                current = current.Replace(", and ", ", ");
                _banner.ChangeText(current + ", and " + shorten);
            }
            // any task to replace entire banner
            else
            {
                Debug.Log("Change to " + words);
                _banner.ChangeText(words);
            }
        }

        if (Found)
        {
            Debug.Log("Found item");
                if (current.Contains(", and " + shorten))
                {
                    current = current.Replace(", ", ", and ");
                    current = current.Replace(", and " + shorten, "");
                }
                current = current.Replace(", " + shorten, "");
                current = current.Replace(shorten, "");

                Debug.Log("updated current = " + current);
                // found everything go to franks yard in L3
                if (Systems.Inventory.HasItem(Resources.Load<Item>("Items/CleanMustardWater"), 1)
                    && Systems.Inventory.HasItem(Resources.Load<Item>("Items/Rope"), 1)
                    && Systems.Inventory.HasItem(Resources.Load<Item>("Items/Shovel"), 1))
                {
                    Debug.Log("Found alll things");
                    _banner.ChangeText("Find Frank's backyard");
                }

                //found everything for now but more things to find
                else if (current == "Find")
                {
                    Debug.Log("Complete list but more things");
                    _banner.ChangeText("Talk to survivors");
                }
                //things left on list to find
                else
                {
                    Debug.Log("Remaining of list");
                    _banner.ChangeText(current);
                }
            
        }
    }
}
