using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScreenDisplayer : UIElement
{
    private GameObject toggler;
    private bool musicIsOff;
    private bool sfxIsOff;
    // Start is called before the first frame update
    void Start()
    {
        toggler = GameObject.Find("EscapeClosed");
        UIManager.Instance.Initialize(this);

        /*print("EscapeClosed start method");

        musicIsOff = SavedData.musicOff;
        if (!musicIsOff)
        {
            Debug.Log("music is on");
            GameObject.Find("Audio").SetActive(true);
        }
        else
        {
            Debug.Log("music is off");
            GameObject.Find("Audio").SetActive(false);
        }
        sfxIsOff = SavedData.sfxOff;
        if (!sfxIsOff)
        {
            Debug.Log("soundFX is on");
            GameObject.Find("SoundFX").SetActive(true);
        }
        else
        {
            Debug.Log("soundFX is off");
            GameObject.Find("SoundFX").SetActive(false);
        }*/
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Open()
    {
        toggler.SetActive(true);
    }

    public override void Close()
    {
        toggler.SetActive(false);
    }
}
