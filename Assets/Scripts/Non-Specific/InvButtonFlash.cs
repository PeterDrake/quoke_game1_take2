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
        if (startOnAwake) { isOn = true; }
    }

    // Update is called once per frame
    void Update()
    {
        Throb(isOn);
    }

    private void Throb(bool isFlashing)
    {
        if (isFlashing)
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
        isOn = true;
    }

    public void ThrobOff()
    {
        isOn = false;
    }
}
