using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Water;

public class MiniGameMasterPitLatrine : MonoBehaviour
{
    public bool Situation1;    //Low ground
    public bool Situation2;    //High ground
    public bool UseClicked;
    
    public GameObject S1Folder;
    public GameObject S2Folder;
    public GameObject S1Pit2;
    public GameObject Water;
    public GameObject ErrorScreen;
    public GameObject TryHighGround;

    public GameObject Use;
    public GameObject Dig;
    public GameObject Dig2;

    public void Start()
    {
        if (Situation1)
        {
            S1Folder.SetActive(true);
            S2Folder.SetActive(false);
            Dig.SetActive(true);
            Dig2.SetActive(false);
        }

        else
        {
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
    }
    
    private IEnumerator TooShallow()
    {
        ErrorScreen.SetActive(true);
        yield return new WaitForSeconds(4f);
        ErrorScreen.SetActive(false);
        UseClicked = false;
    }
    
    private void UseIsClicked()
    {
        UseClicked = true;
    }
    
    private IEnumerator TryElsewhere()
    {
        yield return new WaitForSeconds(3f);
        TryHighGround.SetActive(true);
    }
    
}
