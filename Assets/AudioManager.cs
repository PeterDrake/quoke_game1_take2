using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    private static readonly string FirstPlay = "FirstPlay";
    private static readonly string musicPref = "musicPref";
    private static readonly string sfxPref = "sfxPref";

    private int firstPlayInt;
    public Slider musicSlider, sfxSlider;
    private float musicFloat, sfxFloat;
    public AudioSource[] musicAudio;
    public AudioSource[] sfxAudio;

    void Start()
    {
        firstPlayInt = PlayerPrefs.GetInt(FirstPlay);

        if(firstPlayInt==0)
        {
            musicFloat = 0.25f;
            sfxFloat = 0.5f;
            musicSlider.value = musicFloat;
            sfxSlider.value = sfxFloat;
            PlayerPrefs.SetFloat(musicPref, musicFloat);
            PlayerPrefs.SetFloat(sfxPref, sfxFloat);
            PlayerPrefs.SetInt(FirstPlay, -1);
            print("StartIf");
        }
        else
        {
            musicFloat = PlayerPrefs.GetFloat(musicPref);
            musicSlider.value = musicFloat;
            sfxFloat = PlayerPrefs.GetFloat(sfxPref);
            sfxSlider.value = sfxFloat;
            print("StartElse");
        }
    }

    public void SaveSoundSettings()
    {
        PlayerPrefs.SetFloat(musicPref, musicSlider.value);
        PlayerPrefs.SetFloat(sfxPref, sfxSlider.value);
    }

    void OnApplicationFocus(bool inFocus)
    {
        if(!inFocus)
        {
            SaveSoundSettings();
        }
    }

    public void UpdateSound()
    {
        for (int i=0; i<musicAudio.Length; i++)
        {
            musicAudio[i].volume = musicSlider.value;
        }
        for (int j=0; j<sfxAudio.Length; j++)
        {
            sfxAudio[j].volume = sfxSlider.value;
        }
        //SaveSoundSettings();
    }
}
