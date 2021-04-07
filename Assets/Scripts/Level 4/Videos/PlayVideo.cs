using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.Events;


public class PlayVideo : MonoBehaviour
{
    public VideoPlayer videoPlayer;
    public string fileName;
    public bool play;

    public UnityAction CloseVideo;


    // Start is called before the first frame update
    void Start()
    {
        videoPlayer.source = VideoSource.Url;
        string filepath = System.IO.Path.Combine(Application.streamingAssetsPath, fileName);
        videoPlayer.GetComponent<VideoPlayer>().url = filepath;
        print("preparing video now!");
        videoPlayer.Prepare();
        play = false;
        videoPlayer.loopPointReached += EndofVideo;
    }

    void Update(){
        if (play){
            videoPlayer.Play();
            play = false;
        }
    }

    void EndofVideo(VideoPlayer vp){
        print("Video just finished");
        CloseVideo.Invoke();
    }
}
