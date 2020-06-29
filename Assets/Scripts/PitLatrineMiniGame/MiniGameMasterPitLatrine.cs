﻿using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Water;

public class MiniGameMasterPitLatrine : MonoBehaviour
{
    public bool Situation1;    //Low ground
    public bool Situation2;    //High ground
    public GameObject Camera;
    public bool UseClicked;
    private bool check;
    
    public GameObject S1Folder;
    public GameObject S2Folder;
    public GameObject S1Pit2;
    public GameObject Water;
    
    public GameObject ErrorScreen;
    public GameObject TryHighGround;
    public GameObject ErosionScreen;
    public GameObject WinScreen;

    public GameObject S2Pit1;
    public GameObject S2Pit2;
    public GameObject S2Pit3;

    public GameObject Use;
    public GameObject Dig;
    public GameObject Dig2;

    public void Start()
    {
        if (Situation1)
        {
            Camera.transform.position = new Vector3(72.409f, 1.763f, -139.003f);
            S1Folder.SetActive(true);
            S2Folder.SetActive(false);
            Dig.SetActive(true);
            Dig2.SetActive(false);
        }

        else
        {
            Camera.transform.position = new Vector3(77.6f, 2.9f, -134.4f);
            S1Folder.SetActive(false);
            S2Folder.SetActive(true);
            Dig.SetActive(false);
            Dig2.SetActive(true);
        }
    }
    
    public void Update()
    {
        if (Situation1)
        {
            if (S1Pit2.activeSelf == false && UseClicked==true)
            {
                StartCoroutine(nameof(TooShallow));
            }

            if (Water.activeSelf==true)
            {
                Use.SetActive(false);
                Dig.SetActive(false);
                StartCoroutine(nameof(TryElsewhere));
            }
        }

        else
        {
            if (!S2Pit2.activeSelf && !S2Pit3.activeSelf && UseClicked)
            {
                StartCoroutine(nameof(TooShallow));
            }

            if (S2Pit2.activeSelf && !S2Pit3.activeSelf && UseClicked)
            {
                Use.SetActive(false);
                Dig2.SetActive(false);
                WinScreen.SetActive(true);
            }

            if (S2Pit3.activeSelf && !check)
            {
                check = true;
                StartCoroutine(nameof(TooDeep));
            }

            if (!S2Pit3.activeSelf)
            {
                check = false;
            }
        }
    }
    
    private IEnumerator TooShallow()
    {
        ErrorScreen.SetActive(true);
        yield return new WaitForSeconds(4f);
        ErrorScreen.SetActive(false);
        UseClicked = false;
    }

    private IEnumerator TooDeep()
    {
        Dig2.SetActive(false);
        Use.SetActive(false);
        yield return new WaitForSeconds(3f);
        ErosionScreen.SetActive(true);
        yield return new WaitForSeconds(3f); 
        ErosionScreen.SetActive(false);
        Dig2.SetActive(true);
        Use.SetActive(true);
    }

    private void UseIsClicked()
    {
        UseClicked = true;
    }
    
    private IEnumerator TryElsewhere()
    {
        yield return new WaitForSeconds(3f);
        TryHighGround.SetActive(true);
        UseClicked = false;
    }

}