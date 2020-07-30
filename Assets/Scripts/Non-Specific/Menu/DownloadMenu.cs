﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class DownloadMenu: MonoBehaviour

{
    private Downloads downloader;
    //loads the scene with the name you give it
    public void downloadResource(string docname)
    {
        downloader = GameObject.Find("Downloader").GetComponent<Downloads>();
        downloader.sendToLog(docname);
    }
}
