using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DownloadMenu: MonoBehaviour

{
    private Downloads downloader;
    private Image icon;
    public Button button;

    private LogToServer logger;

    private void Start()
    {
        logger = GameObject.Find("Logger").GetComponent<LogToServer>();
    }

    //downloads the document with the name you give it
    public void downloadResource(string docname)
    {
        logger.sendToLog("Downloaded " + docname + " document");
    Application.OpenURL("/downloadHandout.php/?docname="+docname);
    /*
        downloader = GameObject.Find("Downloader").GetComponent<Downloads>();
        downloader.sendToLog(docname); */
        icon = gameObject.GetComponent<Image>();
        /*
        downloader = GameObject.Find("Downloader").GetComponent<Downloads>();
        downloader.sendToLog(docname);
        */
        icon.color = Color.green;
        button.interactable = false;
    }
}
