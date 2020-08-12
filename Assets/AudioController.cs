using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System.Net.NetworkInformation;

public class AudioController : MonoBehaviour
{
    private Slider musicSlide;
    private VideoPlayer video;

    // Start is called before the first frame update
    void Start()
    {
        musicSlide = GameObject.Find("AudioManager").GetComponent<AudioManager>().musicSlider;
        video = GetComponent<VideoPlayer>();
        video.SetDirectAudioVolume(0, musicSlide.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
