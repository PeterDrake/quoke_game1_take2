using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Pamphlet : MonoBehaviour
{
    public GameObject pamphlet;
    public Text buttonText;

    private string openText = "Open Pamphlet";
    private string closeText = "Close Pamphlet";

    private bool open;

    private LogToServer logger;

    private void Awake()
    {
        logger = GameObject.Find("Logger").GetComponent<LogToServer>();
        pamphlet.SetActive(false);
        buttonText.text = openText;
    }

    public void toggle()
    {
        if (open)
        {
            Debug.Log("Closed pamphlet");
            logger.sendToLog("Closed pamphlet","MINIGAME");
            pamphlet.SetActive(false);
            buttonText.text = openText;
        }
        else
        {
            Debug.Log("Opened pamphlet");
            logger.sendToLog("Opened pamphlet","MINIGAME");
            pamphlet.SetActive(true);
            buttonText.text = closeText;
        }
        open = !open;
    }

}

