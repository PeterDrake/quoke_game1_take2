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
    public bool doubleVol;
    public bool halfVolume;
    public bool threeFourthsVol;

    // Start is called before the first frame update
    void Start()
    {
        musicSlide = GameObject.Find("AudioManager").GetComponent<AudioManager>().musicSlider;
        video = GetComponent<VideoPlayer>();
        if (doubleVol)
        {
            if (musicSlide.value < 0.5f) { volume = musicSlide.value * 2f; }
            else { volume = 1f; }
        }
        else if (halfVolume) { volume = musicSlide.value * 0.5f; }
        else if (threeFourthsVol) { volume = musicSlide.value * 0.75f; }
        else { volume = musicSlide.value; }
        video.SetDirectAudioVolume(0, volume);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
