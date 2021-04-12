using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SadCorgiVideoInteraction : MonoBehaviour
{
    private GameObject canvi;
    private GameObject camera;
    private GameObject vcam;
    private GameObject sunlight;



    public void OpenSadCorgi()
    {
        SceneManager.LoadScene("VideoSadCorgi", LoadSceneMode.Additive);
        SceneManager.sceneLoaded += StartVideo;
    }

    private void StartVideo(Scene scn, LoadSceneMode lsm)
    {
        // Systems.Status.Pause();
        SceneManager.sceneLoaded -= StartVideo;

        if (GameObject.Find("Music") != null) { GameObject.Find("Music").GetComponent<AudioSource>().Pause(); }

        // (canvi = GameObject.Find("MiniGameClose")).SetActive(false);
        // (camera = GameObject.Find("Main Camera")).SetActive(false);
        // (vcam = GameObject.Find("CM vcam1")).SetActive(false);
        // (sunlight = GameObject.Find("Sunlight")).SetActive(false);

        GameObject.Find("SadCorgiController").GetComponent<PlayVideo>().CloseVideo += CloseVideo;



    }

    private void CloseVideo()
    {
        // Systems.Status.UnPause();
        SceneManager.UnloadSceneAsync("VideoSadCorgi");

        if (GameObject.Find("Music") != null) { GameObject.Find("Music").GetComponent<AudioSource>().Play(); }

        // camera.SetActive(true);
        // vcam.SetActive(true);
        // canvi.SetActive(true);
        // sunlight.SetActive(true);

        StartCoroutine(GetComponent<IntroToCorgiSaveMiniGame>().EventsAfterSadCorgi());
    }
}
