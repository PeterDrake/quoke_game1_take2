using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.Video;

public class SaveCorgiController : MonoBehaviour
{
    private DragTarp script;
    private VideoPlayer _videoPlayer;

    public GameObject Tarp;
    public GameObject Corgi;
    public GameObject Banner;
    public GameObject VideoBackground;
    public GameObject VideoDisplayer;
    public GameObject Video;

    void Start()
    {
        script = Tarp.GetComponent<DragTarp>();
        _videoPlayer = Video.GetComponent<VideoPlayer>();

    }

    void Update()
    {
        if (Tarp.transform.position.x < -116f)
        {
            if (GameObject.Find("MiniMusic") != null)
            {
                GameObject.Find("MiniMusic").SetActive(false);
            }
            Destroy(script);
            Banner.SetActive(false);
            StartCoroutine(nameof(CorgiSit));
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
        //_videoPlayer.url = System.IO.Path.Combine (Application.streamingAssetsPath,"CorgiFINALE.mp4");
        //_videoPlayer.Play();
        //

    }
}
