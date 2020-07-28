using System.Collections;
using System.Collections.Generic;
using System.Media;
using System.Runtime.Versioning;
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
        shorten = words.Replace("Find ", "");

        //no repeats
        if (current.Contains(shorten) || (ItemToFind != null && Systems.Inventory.HasItem(ItemToFind, 1)))
        { 
            find = false;
            
        }
        //for any find task
        if (find)
        {
            // Find task
            if (words.Contains("Find") && current.Contains("Find"))
            {
                current = current.Replace(", and ", ", ");
                _banner.ChangeText(current + ", and " + shorten);
            }
            // any task to replace entire banner
            else
            {
                _banner.ChangeText(words);
            }
        }
        //for any found task
        if (Found)
        {
            Debug.Log("Found item");
                if (current.Contains(", and " + shorten))
                {
                current = current.Replace(", and " + shorten, "");
                current = current.Replace(", ", ", and ");
                    
                }
                current = current.Replace(", " + shorten, "");
                current = current.Replace(shorten, "");
                current = current.Replace(" ,", "");
                current = current.Replace("Find and", "Find");

                // found everything go to franks yard in L3
                if (Systems.Inventory.HasItem(Resources.Load<Item>("Items/CleanMustardWater"), 1)
                    && Systems.Inventory.HasItem(Resources.Load<Item>("Items/Rope"), 1)
                    && Systems.Inventory.HasItem(Resources.Load<Item>("Items/Shovel"), 1))
                {
                    _banner.ChangeText("Find Frank's back yard");
                }

            else if (Systems.Inventory.HasItem(Resources.Load<Item>("Items/Shovel"), 1))
            {
                _banner.ChangeText("Find a rope");
            }

            else if (Systems.Inventory.HasItem(Resources.Load<Item>("Items/Rope"), 1))
            {
                _banner.ChangeText("Find a shovel");
            }

            else if (Systems.Inventory.HasItem(Resources.Load<Item>("Items/DirtyMustardWater"), 1))
            {
                _banner.ChangeText("Add tablets from inventory to clean water");
            }
            else if (Systems.Inventory.HasItem(Resources.Load<Item>("Items/Gun"), 1))
            {
                _banner.ChangeText("Throw away the gun, then ask Zelda to enter the shelter");
            }
            //else if (Systems.Inventory.HasItem(Resources.Load<Item>("Items/Gun"), 0))
            //{
            //    _banner.ChangeText("Enter the shelter");
            //}
            //else if (Systems.Inventory.HasItem(Resources.Load<Item>("Items/CleanMustardWater"), 1))
            //{
            //    _banner.ChangeText("Go talk to Zelda");
            //}

            //if (Systems.Inventory.HasItem(Resources.Load<Item>("Items/DirtyMustardWater"), 1))
            //{
            // _banner.ChangeText("Add tablets from inventory to clean water");
            //}
            //  if (Systems.Inventory.HasItem(Resources.Load<Item>("Items/CleanMustardWater"), 1) && Systems.Inventory.HasItem(Resources.Load<Item>("Items/Shovel"), 1))
            //  {
            //     _banner.ChangeText("Talk to Frank about building a pit latrine");
            // }
            //found everything for now but more things to find
            else if (current == "Find")
                {
                    _banner.ChangeText("Talk to survivors");
                }
                //things left on list to find
                else
                {
                    _banner.ChangeText(current);
                }
        }
    }
}
