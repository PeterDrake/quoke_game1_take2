﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class L2Aftershock : MonoBehaviour
{
    public ObjectDropper objectDropper;
    public void Start()
    {
        QuakeManager.Instance.OnQuake.AddListener(OnQuake);
    }

    private void OnQuake()
    {
        if (QuakeManager.Instance.Aftershock)
        {
            //objectDropper.Drop();
            Debug.Log("KILL ME");
            Logger.Instance.Log("Aftershock Started");
            Systems.Status.PlayerDeath("The house collapsed in an aftershock!");
            
        }
    }
}
