using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
using Image = UnityEngine.UIElements.Image;

public class BoxCheck : MonoBehaviour
{
    public string itemInBox;
    public string correctTag;
    private MiniGameMaster MasterCheck;
    private FrameColorChange Frame;

    //use this funciton when an item collider is staying in this box collider
    // public void OnTriggerStay(Collider item)
    // {
    //     item.gameObject.GetComponent<DragObject>().PlaceItemInBox(this.gameObject);
    //     item.gameObject.GetComponent<BoxCollider>().enabled = false;
    //     item.gameObject.GetComponent<DragObject>().SetLastCollision(this.name);
    //     BlinkFrame = gameObject.GetComponent<BlinkFrame>();
    
    //     BlinkFrame.Blink();
    //     Debug.Log(item.name.ToString() + "enters " + this.name);
    // }
    //use this function when an item collider exits this box collider
    // public void OnTriggerExit(Collider item)
    // {
    //     item.gameObject.GetComponent<DragObject>().inBox = false;
    //     // print("exit");
    //     BlinkFrame.StopBlink();
    // }
    void Start()
    {
        Frame = gameObject.GetComponent<FrameColorChange>();
        MasterCheck = GameObject.Find("MinigameMaster").GetComponent<MiniGameMaster>();
        itemInBox = null;
    }

    void Update()
    {
        if (itemInBox != null)
        {
            if (itemInBox.Equals(correctTag))
            {
                Frame.Correct();
                // gameObject.GetComponent<BoxCollider>().enabled = false;
            }
            else 
            {
                Frame.Wrong();
            }
        }
        //need ITEM from drag object.
        //if item is not null then update box color && update master && delete things
    }

    // public void StatusCheck(Collider other)
    // {
    //     BlinkFrame.StopBlink();
    //     if (other.CompareTag(correctTag))
    //     { 
    //         //Debug.Log(correctTag +" is correct");
    //         MasterCheck = GameObject.Find("MinigameMaster").GetComponent<MiniGameMaster>();
    //         BlinkFrame.Correct();
    //         Destroy(other.GetComponent<DragObject>());
    //         if (correctTag == "Bucket")
    //         {
    //             if (this.name == "PeeBucketBox")
    //             {
    //                 MasterCheck.PeeBucket = true;
    //             }
    //             else if (this.name == "PooBucketBox")
    //             {
    //                 MasterCheck.PooBucket = true;
    //             }

    //         }
    //         if (correctTag == "PlasticBag")
    //         {
    //             MasterCheck.PlasticBag = true;
    //         }
    //         if (correctTag == "Poop")
    //         {
    //             MasterCheck.Poop = true;
    //         }
    //         if (correctTag == "ToiletPaper")
    //         {
    //             MasterCheck.ToiletPaper = true;
    //         }
    //         if (correctTag == "Sawdust")
    //         {
    //             MasterCheck.Sawdust = true;
    //         }
    //         if (correctTag == "Pee")
    //         {
    //             MasterCheck.Pee = true;
    //         }

    //         if (MasterCheck.PeeBucket && MasterCheck.PooBucket && MasterCheck.PlasticBag && MasterCheck.Poop && MasterCheck.ToiletPaper && MasterCheck.Sawdust && MasterCheck.Pee)
    //         {
    //             StartCoroutine(BlinkText());
    //         }
    //     }
    //     else
    //     {
    //         BlinkFrame.Wrong();
    //         gameObject.GetComponent<BoxCollider>().enabled = false;
    //         //Debug.Log("An item is in the wrong place"); 
    //     }
    // }

}
