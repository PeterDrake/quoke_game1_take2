using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InvButtonFlash : MonoBehaviour
{
    public bool startOnAwake;
    private bool isOn;
    [SerializeField] private Image TheFlash;
    public Color newInvColor;


    // Start is called before the first frame update
    void Start()
    {
        if (startOnAwake) { SavedData.addInv = true; }
    }

    // Update is called once per frame
    void Update()
    {
        isOn = SavedData.addInv;
        Throb();
    }

    private void Throb()
    {
        if (isOn)
        {
            TheFlash.color = Color.Lerp(newInvColor, Color.clear, Mathf.PingPong(Time.time, .5f));
        }
        else
        {
            TheFlash.color = Color.clear;
        }
    }

    public void ThrobOn()
    {
        SavedData.addInv = true;
    }

    public void ThrobOff()
    {
        SavedData.addInv = false;
    }
}
