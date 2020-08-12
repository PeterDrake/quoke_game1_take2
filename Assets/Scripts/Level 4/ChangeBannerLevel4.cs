using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBannerLevel4 : MonoBehaviour
{
    public InformationCanvas _canvas;
    public string words;
    public string words1;
    public string words2;
    public string words3;
    public string words4;
    public string words5;
    public string words6;



    private bool mulch;
    private bool paper;
    private bool wood;

    public void BannerUpdate()
    {
        if (Systems.Objectives.Check("CompostTalk"))
        {
            if (Systems.Inventory.HasItem(Resources.Load<Item>("Items/Mulch"), 1))
            {
                print("has mulch");
                mulch = true;
            }
            if (Systems.Inventory.HasItem(Resources.Load<Item>("Items/ShreddedPaper"), 1))
            {
                print("has shreddedpaper");
                paper = true;
            }
            if (Systems.Inventory.HasItem(Resources.Load<Item>("Items/Wood"), 1))
            {
                print("has wood");
                wood = true;
            }
            ChangeBanners();
        }
        else
        {
            print("didnt talk to bruce yet");
        }
    }


    public void ChangeBanners()
    {
        if (mulch && !paper && !wood)
        {
            print("MULCHHH ONLY");
        }
        if (!mulch && paper && !wood)
        {
            print("PAPER ONLY");
        }
        if (!mulch && !paper && wood)
        {
            print("WOOD ONLY");
        }
        if (mulch && paper && !wood)
        {
            print("find wood");
        }
        if (mulch && !paper && wood)
        {
            print("find paper");
        }
        if (!mulch && paper && wood)
        {
            print("find mulch");
        }
        if (mulch && paper && wood)
        {
            print("I GOT ALL THREE!!!");
        }

    }




    public void Change()
    {
        /*if (Systems.Inventory.HasItem(Resources.Load<Item>("Items/Mulch"), 1)
                   && Systems.Inventory.HasItem(Resources.Load<Item>("Items/ShreddedPaper"), 1)
                   && Systems.Inventory.HasItem(Resources.Load<Item>("Items/Wood"), 1))
        {
            //_canvas.ChangeText("Help Bruce build the composting waste processor");
            _canvas.ChangeText(words);
        }*/



        if (Systems.Inventory.HasItem(Resources.Load<Item>("Items/Mulch"), 0)
                   && Systems.Inventory.HasItem(Resources.Load<Item>("Items/ShreddedPaper"), 0)
                   && Systems.Inventory.HasItem(Resources.Load<Item>("Items/Wood"), 1))
        {
            //_canvas.ChangeText("Find carbon material");
            _canvas.ChangeText(words1);
        }

        if (Systems.Inventory.HasItem(Resources.Load<Item>("Items/Mulch"), 1)
                   && Systems.Inventory.HasItem(Resources.Load<Item>("Items/ShreddedPaper"), 0)
                   && Systems.Inventory.HasItem(Resources.Load<Item>("Items/Wood"), 0))
        {
            //_canvas.ChangeText("Find more carbon material and wood");
            _canvas.ChangeText(words2);
        }

        if (Systems.Inventory.HasItem(Resources.Load<Item>("Items/Mulch"), 0)
                   && Systems.Inventory.HasItem(Resources.Load<Item>("Items/ShreddedPaper"), 1)
                   && Systems.Inventory.HasItem(Resources.Load<Item>("Items/Wood"), 0))
        {
            //_canvas.ChangeText("Find more carbon material and wood");
            _canvas.ChangeText(words3);
        }

        if (Systems.Inventory.HasItem(Resources.Load<Item>("Items/Mulch"), 1)
                   && Systems.Inventory.HasItem(Resources.Load<Item>("Items/ShreddedPaper"), 1)
                   && Systems.Inventory.HasItem(Resources.Load<Item>("Items/Wood"), 0))
        {
            //_canvas.ChangeText("Find wood");
            _canvas.ChangeText(words4);
        }

        if (Systems.Inventory.HasItem(Resources.Load<Item>("Items/Mulch"), 0)
                   && Systems.Inventory.HasItem(Resources.Load<Item>("Items/ShreddedPaper"), 1)
                   && Systems.Inventory.HasItem(Resources.Load<Item>("Items/Wood"), 1))
        {
            //_canvas.ChangeText("Find more carbon material");
            _canvas.ChangeText(words5);
        }

        /*if (Systems.Inventory.HasItem(Resources.Load<Item>("Items/Mulch"), 1)
                   && Systems.Inventory.HasItem(Resources.Load<Item>("Items/ShreddedPaper"), 0)
                   && Systems.Inventory.HasItem(Resources.Load<Item>("Items/Wood"), 1))
        {
            //_canvas.ChangeText("Find more carbon material");
            _canvas.ChangeText(words6);
        }*/

        if (Systems.Inventory.HasItem(Resources.Load<Item>("Items/Mulch"), 1)
                   && Systems.Inventory.HasItem(Resources.Load<Item>("Items/ShreddedPaper"), 1)
                   && Systems.Inventory.HasItem(Resources.Load<Item>("Items/Wood"), 1))
        {
            //_canvas.ChangeText("Help Bruce build the composting waste processor");
            _canvas.ChangeText(words);
        }
    }
}
