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
    private float volume;
    public bool halfVolume;

    // Start is called before the first frame update
    void Start()
    {
        musicSlide = GameObject.Find("AudioManager").GetComponent<AudioManager>().musicSlider;
        video = GetComponent<VideoPlayer>();
        if (halfVolume) { volume = musicSlide.value * 0.5f; }
        else { volume = musicSlide.value; }
        video.SetDirectAudioVolume(0, volume);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
