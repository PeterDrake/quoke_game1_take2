﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class SadCorgiManager : MonoBehaviour
{
    public GameObject InTheMeantimeCanvas;
    public GameObject MiniGameClose;
    public GameObject VideoDisplayer;
    public GameObject VideoBackground;
    public GameObject Video;

    private bool check;
    private float timer;

    private void Start()
    {
        Time.timeScale = 1;
        StartCoroutine(nameof(StartCutScene));
    }

    void Update()
    {
        if (check)
        {
            Destroy(this);
        }
    }

    private IEnumerator StartCutScene()
    {
        Time.timeScale = 1;
        //if the sanitation is built, wait for four seconds and trigger "In the meantime..." slide
        Debug.Log("Waiting for 1.5 seconds");
        yield return new WaitForSeconds(1.5f);
        MiniGameClose.SetActive(false);
        GameObject.Find("Black Background").SetActive(false);
        if (GameObject.Find("Music") != null)
        {
            GameObject.Find("Music").GetComponent<AudioSource>().Pause();
        }

        InTheMeantimeCanvas.SetActive(true);

        //then trigger the video
        Debug.Log("Waiting for 3 seconds");
        yield return new WaitForSeconds(3f);
        Systems.Status.Pause();

        VideoBackground.SetActive(true);
        VideoDisplayer.SetActive(true);
        Video.SetActive(true);
        Video.GetComponent<VideoPlayer>().Play();

        InTheMeantimeCanvas.SetActive(false);
        yield return new WaitForSeconds(18f);
        
        string filepath = System.IO.Path.Combine(Application.streamingAssetsPath, "Sad2.mp4");
        Video.GetComponent<VideoPlayer>().url = filepath;
        Video.GetComponent<VideoPlayer>().Play();
        yield return new WaitForSeconds(27f);

        
        filepath = System.IO.Path.Combine(Application.streamingAssetsPath, "Sad3.mp4");
        Video.GetComponent<VideoPlayer>().url = filepath;
        Video.GetComponent<VideoPlayer>().Play();
        yield return new WaitForSeconds(13f);
        SceneManager.LoadSceneAsync("Scenes/Levels/Level 5");
        yield return new WaitForSeconds(3f);
        //yield return new WaitForSeconds(63f);

        
        //turn off the video

        //Systems.Status.UnPause();
        //SceneManager.LoadSceneAsync("Scenes/Levels/Level 5");
        VideoBackground.SetActive(false);
        VideoDisplayer.SetActive(false);
        Video.SetActive(false);
        if (GameObject.Find("Music") != null)
        {
            GameObject.Find("Music").GetComponent<AudioSource>().Play();
        }

        MiniGameClose.SetActive(true);
        check = true;
    }
}
