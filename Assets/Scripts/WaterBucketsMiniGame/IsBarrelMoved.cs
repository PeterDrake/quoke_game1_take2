﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Image = UnityEngine.UIElements.Image;

public class IsBarrelMoved : MonoBehaviour
{

    public string correctTag;

    private MiniGameMain CheckBarrelPosition;

    public Button theButton;

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(correctTag))
        {
            //Debug.Log(correctTag +" is correct");
            CheckBarrelPosition = GameObject.Find("MiniGameMain").GetComponent<MiniGameMain>();
            if (correctTag == "Barrel")
            {
                CheckBarrelPosition.Barrel = true;
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
            CheckBarrelPosition = GameObject.Find("MiniGameMain").GetComponent<MiniGameMain>();
            if (correctTag == "Barrel")
            {
                CheckBarrelPosition.Barrel = false;
            }
        }
        else
        {
            //Debug.Log("An item is in the wrong place"); 
        }
    }

}
