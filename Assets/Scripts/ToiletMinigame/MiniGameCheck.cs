using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UIElements.Image;

public class MiniGameCheck : MonoBehaviour
{

    public string correctTag;

    private MiniGameMaster MasterCheck;

    public Button theButton;
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(correctTag))
        {
            //Debug.Log(correctTag +" is correct");
            MasterCheck = GameObject.Find("MinigameMaster").GetComponent<MiniGameMaster>();
            if (correctTag == "Bucket")
            {
                if (this.name == "Place1a") {
                    MasterCheck.PeeBucket = true;
                }
                else if (this.name == "Place1")
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
            //Debug.Log("An item is in the wrong place"); 
        }
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
   if (other.CompareTag(correctTag))
   {
       MasterCheck = GameObject.Find("MinigameMaster").GetComponent<MiniGameMaster>();
       if (correctTag == "Bucket")
       {
                if (this.name == "Place1a")
                {
                    MasterCheck.PeeBucket = false;
                }
                else if (this.name == "Place1")
                {
                    MasterCheck.PooBucket = false;
                }
            }
       if (correctTag == "PlasticBag")
       {
           MasterCheck.PlasticBag = false;
       }
       if (correctTag == "Poop")
       {
           MasterCheck.Poop = false;
       }
       if (correctTag == "ToiletPaper")
       {
           MasterCheck.ToiletPaper = false;
       }
       if (correctTag == "Sawdust")
       {
           MasterCheck.Sawdust = false;
       }
       if (correctTag == "Pee")
       {
           MasterCheck.Pee = false;
       }
   }
   else
   {
       //Debug.Log("An item is in the wrong place"); 
   }
} 

}
