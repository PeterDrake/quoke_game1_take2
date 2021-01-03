using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.Video;

public class SaveCorgiController : MonoBehaviour
{
    private DragTarp script;
    private VideoPlayer _videoPlayer;

    public GameObject camera;
    public GameObject Frank;
    public GameObject Tarp;
    public GameObject Corgi;
    public GameObject Banner;
    public GameObject VideoBackground;
    public GameObject VideoDisplayer;
    public GameObject Video;
    public GameObject Win;
    public AudioSource sound;

    private bool winScreen;
    private bool gameOver;
    private bool start;

    void Start()
    {
        sound.Play();
        script = Tarp.GetComponent<DragTarp>();
        _videoPlayer = Video.GetComponent<VideoPlayer>();
        _videoPlayer.source = VideoSource.Url;
        string filepath = System.IO.Path.Combine(Application.streamingAssetsPath, "CorgiFINALE_short.mp4");
        _videoPlayer.url = filepath;
        winScreen = false;
        gameOver = false;
        start = false;
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
                sound.Stop();
                // StartVideo();
                StartCoroutine(nameof(PlayVideo));
            }
            if (Tarp.transform.position.x > -110f)
            {
                print("too far left");
                Tarp.transform.position = new Vector3(-113f,107.1427f,-156f);
            }

        }
        else if (start && !gameOver)
        {
            StopAllCoroutines();

            if (!_videoPlayer.isPlaying)
            {
                print("video playing done");
                _videoPlayer.Stop();
                Video.SetActive(false);
                Destroy(Video);
                Destroy(VideoBackground);
                Destroy(VideoDisplayer);
                ShowWinScreen();
            }
        }
    }
    private IEnumerator PlayVideo()
    {
        print("starting video now");
        yield return new WaitForSeconds(.5f);
        Video.SetActive(true);
        VideoDisplayer.SetActive(true);
        VideoBackground.SetActive(true);
        Video.GetComponent<VideoPlayer>().Play();  
        start = true;
        yield return new WaitForSeconds(1f);
        //_videoPlayer.url = System.IO.Path.Combine (Application.streamingAssetsPath,"CorgiFINALE.mp4");
        //_videoPlayer.Play();
        //
    }

/*
    private IEnumerator CorgiSit()
    {
        yield return new WaitForSeconds(1f);
        Corgi.GetComponent<Animator>().enabled = true;
        //yield return new WaitForSeconds(1f);
        StartCoroutine(nameof(PlayVideo));
    }

    */

    private void ShowWinScreen(){
        // GameObject.Find("Mo1").GetComponent<SaveCorgiVisit>().CorgiRescue();
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
