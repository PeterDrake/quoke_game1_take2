using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BarrelVisit : MonoBehaviour
{
    private const string MiniGameSceneName = "WaterBucketMiniGame";

    private InteractWithObject _interact;
    private InventoryHelper _inventory;

    public GameObject BarrelEnd;
    public GameObject DrainPipe;
    public GameObject Particles;

    private GameObject canvi;
    private GameObject camera;
    private GameObject vcam;
    private GameObject sunlight;
    //private GameObject levelAudio;


    void Start()
    {
        _interact = GetComponent<InteractWithObject>();
    }

    public void Interaction()
    {
        //if ((Conditions ^ 0xF) == 0) // talked with Ahmad
        //{
        SceneManager.LoadScene(MiniGameSceneName, LoadSceneMode.Additive);
        Debug.Log("Hello");
        SceneManager.sceneLoaded += StartMinigame;
        _interact.enabled = false;
        //}
        //else
        //{
          //  _interact.SetInteractText("Go talk to Ahmad about water-collecting system");
        //}
    }

    private void StartMinigame(Scene scn, LoadSceneMode lsm)
    {
        Systems.Status.Pause();
        SceneManager.sceneLoaded -= StartMinigame;

        (canvi = GameObject.Find("Canvi")).SetActive(false);
        (camera = GameObject.Find("Main Camera")).SetActive(false);
        (vcam = GameObject.Find("CM vcam1")).SetActive(false);
        (sunlight = GameObject.Find("Sunlight")).SetActive(false);
        //(levelAudio = GameObject.Find("Audio")).SetActive(false);

        GameObject.Find("MiniGameMain").GetComponent<MiniGameMain>().OnWin += MiniGameFinished;
        GameObject.Find("MiniGameMain").GetComponent<MiniGameMain>().OnExit += MiniGameLeave;
    }

    private void MiniGameLeave()
    {
        SceneManager.UnloadSceneAsync(MiniGameSceneName);
        canvi.SetActive(true);
        camera.SetActive(true);
        vcam.SetActive(true);
        sunlight.SetActive(true);
        //levelAudio.SetActive(true);
        _interact.Kill();
    }
    private void MiniGameFinished()//this is not getting called
    {
        Systems.Status.UnPause();
        DrainPipe.SetActive(false);
        BarrelEnd.SetActive(true);
        Particles.SetActive(false);

        SceneManager.UnloadSceneAsync(MiniGameSceneName);

        Systems.Objectives.Satisfy("BarrelReady");
        camera.SetActive(true);
        vcam.SetActive(true);
        canvi.SetActive(true);
        sunlight.SetActive(true);
        //levelAudio.SetActive(true);
    }
}
