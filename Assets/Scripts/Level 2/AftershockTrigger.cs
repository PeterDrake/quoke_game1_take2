using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AftershockTrigger : MonoBehaviour
{
    private bool aftershock = false;

    // Attached to a game object along with a collider to detect when the player last left the house
    public InformationCanvas _canvas;
    private void OnTriggerExit(Collider other)
    {
        Debug.Log("CHANGE TO TWO");
        QuakeManager.Instance.TriggerCountdown(5f);
        aftershock = true;
        _canvas.ChangeText("Have a look around...");
        //Logger.Instance.Log("Player has left the house");
        LogToServer logger = GameObject.Find("Logger").GetComponent<LogToServer>();
        logger.sendToLog("Player left the house");
        Destroy(gameObject);
    }
}
