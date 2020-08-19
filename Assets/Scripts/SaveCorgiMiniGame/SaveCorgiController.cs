﻿using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.Video;

public class SaveCorgiController : MonoBehaviour
{
    private DragTarp script;
    private VideoPlayer _videoPlayer;

    public GameObject camera;
    public GameObject Tarp;
    public GameObject Corgi;
    public GameObject Banner;
    public GameObject VideoBackground;
    public GameObject VideoDisplayer;
    public GameObject Video;
    public GameObject Win;

    private bool winScreen;
    private bool gameOver;

    void Start()
    {
        script = Tarp.GetComponent<DragTarp>();
        _videoPlayer = Video.GetComponent<VideoPlayer>();
        winScreen = false;
        gameOver = false;
    }

    void Update()
    {
        if (Tarp.transform.position.x < -116f & !gameOver)
        {
            if (GameObject.Find("MiniMusic") != null)
            {
                GameObject.Find("MiniMusic").SetActive(false);
            }
            Destroy(script);
            Banner.SetActive(false);
            StartCoroutine(nameof(CorgiSit));
        }
        if (winScreen)
        {
            StopAllCoroutines();
            winScreen = false;
            gameOver = true;
            print("done WINNEr");
            VideoBackground.SetActive(false);
            VideoDisplayer.SetActive(false);
            Video.SetActive(false);
            Tarp.SetActive(false);
            camera.transform.position = new Vector3(-113,1,-156);
            camera.transform.rotation = Quaternion.Euler(10,180,0);
            //Win.SetActive(true);
        }
    }

    private IEnumerator CorgiSit()
    {
        yield return new WaitForSeconds(1f);
        Corgi.GetComponent<Animator>().enabled = true;
        //yield return new WaitForSeconds(1f);
        StartCoroutine(nameof(PlayVideo));
    }

    private IEnumerator PlayVideo()
    {
        yield return new WaitForSeconds(1f);
        Video.SetActive(true);    
        VideoDisplayer.SetActive(true);
        VideoBackground.SetActive(true);
        yield return new WaitForSeconds(40f);
        _videoPlayer.Stop();
        winScreen = true;


        //_videoPlayer.url = System.IO.Path.Combine (Application.streamingAssetsPath,"CorgiFINALE.mp4");
        //_videoPlayer.Play();
        //
        /*
        //then trigger the video
        yield return new WaitForSeconds(3f);
        VideoBackground.SetActive(true);
        VideoDisplayer.SetActive(true);
        Video.SetActive(true);
        InTheMeantimeCanvas.SetActive(false);
        yield return new WaitForSeconds(63f);

        //turn off the video
        VideoBackground.SetActive(false);
        VideoDisplayer.SetActive(false);
        Video.SetActive(false);
        if (GameObject.Find("Music") != null) { GameObject.Find("Music").GetComponent<AudioSource>().Play(); }
        MiniGameClose.SetActive(true);
        */
    }

}
