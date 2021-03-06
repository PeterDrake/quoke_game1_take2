﻿using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.Video;

public class SaveCorgiController : MonoBehaviour
{
    private DragTarp script;

    public GameObject camera;
    public GameObject Frank;
    public GameObject Tarp;
    public GameObject Corgi;
    public GameObject Banner;
    public GameObject VideoBackground;
    public GameObject VideoDisplayer;
    public GameObject Video;
    public GameObject Win;

    private bool winScreen;
    private bool gameOver;
    private bool start;

    void Start()
    {
        script = Tarp.GetComponent<DragTarp>();
        Video.GetComponent<VideoPlayer>().source = VideoSource.Url;
        string filepath = System.IO.Path.Combine(Application.streamingAssetsPath, "CorgiVideoFINALE.mp4");
        Video.GetComponent<VideoPlayer>().url = filepath;
        winScreen = false;
        gameOver = false;
        start = false;
        Video.GetComponent<VideoPlayer>().loopPointReached += CheckOver;
    }

    void Update()
    {
        if (!gameOver && !start)
        {
            if (Tarp.transform.position.x < -117f )
            {
                if (GameObject.Find("MiniMusic") != null)
                {
                    GameObject.Find("MiniMusic").SetActive(false);
                }
                Destroy(script);
                Banner.SetActive(false);
                // StartVideo();
                StartCoroutine(nameof(PlayVideo));
            }
            if (Tarp.transform.position.x > -110f)
            {
                // print("too far left");
                Tarp.transform.position = new Vector3(-113f,107.1427f,-156f);
            }

        }
    }

    private IEnumerator PlayVideo()
    {
        // print("starting video now");
        yield return new WaitForSeconds(.5f);
        Video.SetActive(true);
        VideoDisplayer.SetActive(true);
        VideoBackground.SetActive(true);
        Video.GetComponent<VideoPlayer>().Play();  
        start = true;
        yield return new WaitForSeconds(1f);
    }

    void CheckOver(UnityEngine.Video.VideoPlayer vp)
    {
     print  ("Video Is Over");
     GameObject.Find("Mo1").GetComponent<SaveCorgiVisit>().CorgiRescue();
        winScreen = false;
        gameOver = true;
        print("done WINNEr");
        VideoBackground.SetActive(false);
        VideoDisplayer.SetActive(false);
        Video.SetActive(false);
        Tarp.SetActive(false);
        Corgi.SetActive(false);
        Frank.SetActive(false);
        camera.transform.position = new Vector3(-112.58f, 109.9f, -141.5f);
        camera.transform.rotation = Quaternion.Euler(10,180,0);
        Win.SetActive(true);
    }
}
