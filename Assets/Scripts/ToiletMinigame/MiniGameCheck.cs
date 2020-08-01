using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.UI;
using Debug = UnityEngine.Debug;
using Image = UnityEngine.UIElements.Image;

public class MiniGameCheck : MonoBehaviour
{

    public string correctTag;

    private MiniGameMaster MasterCheck;
    private BlinkFrame BlinkFrame;

    public Button theButton;
    

    public void OnTriggerStay(Collider other)
    {
        other.gameObject.GetComponent<DragObject>().inBox = true;
        print("enter");
        //lastCollision = other.tag + " put in " + correctTag + " box";
        other.gameObject.GetComponent<DragObject>().SetLastCollision(this.name);
        BlinkFrame = gameObject.GetComponent<BlinkFrame>();
        BlinkFrame.Blink();
    }


    public IEnumerator BlinkText()
    {
        while (true)
        {
            theButton.GetComponent<UnityEngine.UI.Image>().color = Color.green;
            yield return new WaitForSeconds(.3f);
            theButton.GetComponent<UnityEngine.UI.Image>().color = Color.white;
            //theButton.colors = Color.white;
            yield return new WaitForSeconds(.3f);
        }
    }


    public void OnTriggerExit(Collider other)
    {
        other.gameObject.GetComponent<DragObject>().inBox = false;
        print("exit");
        BlinkFrame.StopBlink();
    }


    public void StatusCheck(Collider other)
    {
        BlinkFrame.StopBlink();
        if (other.CompareTag(correctTag))
        { 
            //Debug.Log(correctTag +" is correct");
            MasterCheck = GameObject.Find("MinigameMaster").GetComponent<MiniGameMaster>();
            BlinkFrame.Correct();
            gameObject.GetComponent<BoxCollider>().enabled = false;
            Destroy(other.GetComponent<DragObject>());
            if (correctTag == "Bucket")
            {
                if (this.name == "PeeBucketBox")
                {
                    MasterCheck.PeeBucket = true;
                }
                else if (this.name == "PooBucketBox")
                {
                    MasterCheck.PooBucket = true;
                }

            }
            if (correctTag == "PlasticBag")
            {
                MasterCheck.PlasticBag = true;
            }
            if (correctTag == "Poop")
            {
                MasterCheck.Poop = true;
            }
            if (correctTag == "ToiletPaper")
            {
                MasterCheck.ToiletPaper = true;
            }
            if (correctTag == "Sawdust")
            {
                MasterCheck.Sawdust = true;
            }
            if (correctTag == "Pee")
            {
                MasterCheck.Pee = true;
            }

            if (MasterCheck.PeeBucket && MasterCheck.PooBucket && MasterCheck.PlasticBag && MasterCheck.Poop && MasterCheck.ToiletPaper && MasterCheck.Sawdust && MasterCheck.Pee)
            {
                StartCoroutine(BlinkText());
            }
        }
        else
        {
            BlinkFrame.Wrong();
            //Debug.Log("An item is in the wrong place"); 
        }
    }

}
