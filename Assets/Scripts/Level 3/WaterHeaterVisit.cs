using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterHeaterVisit : MonoBehaviour
{
    private const string MiniGameSceneName = "WaterHeaterMiniGame";


    private InteractWithObject _interact;

    private byte Conditions;

    private GameObject canvi;
    private GameObject camera;
    //private GameObject vcam;
    private GameObject sunlight;

    private void Awake()
    {
    }

    void Start()
    {
        _interact = GetComponent<InteractWithObject>();

    }

    public void Interaction()
    {
            SceneManager.LoadScene(MiniGameSceneName, LoadSceneMode.Additive);
            SceneManager.sceneLoaded += StartMinigame;
   
    }

    private void StartMinigame(Scene scn, LoadSceneMode lsm)
    {
        Systems.Status.Pause();
        SceneManager.sceneLoaded -= StartMinigame;


        (canvi = GameObject.Find("Canvi")).SetActive(false);
        (camera = GameObject.Find("Main Camera")).SetActive(false);
        //(vcam = GameObject.Find("CM vcam1")).SetActive(false);
        (sunlight = GameObject.Find("Sunlight")).SetActive(false);

        GameObject.Find("WaterHeaterMaster").GetComponent<WaterHeaterMaster>().OnWin += MiniGameFinished;
        GameObject.Find("WaterHeaterMaster").GetComponent<WaterHeaterMaster>().OnExit += MiniGameLeave;
    }

    private void MiniGameLeave()
    {
        SceneManager.UnloadSceneAsync(MiniGameSceneName);
        canvi.SetActive(true);
        camera.SetActive(true);
        //vcam.SetActive(true);
        sunlight.SetActive(true);
    }
    private void MiniGameFinished()
    {
        Systems.Status.UnPause();

        SceneManager.UnloadSceneAsync(MiniGameSceneName);

        Systems.Objectives.Satisfy("WATERHEATEREVENT");
        camera.SetActive(true);
        //vcam.SetActive(true);
        canvi.SetActive(true);
        sunlight.SetActive(true);

        // _inventory.RemoveItem( Sanitizer, 1);
        // _inventory.RemoveItem( ToiletPaper, 1);

        //Destroy(gameObject);
        Destroy(this);
        Destroy(gameObject.GetComponent<InteractWithObject>());
        Destroy(gameObject.GetComponent<WaterSwapText>());
    }
}
