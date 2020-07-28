﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterHeaterVisit : MonoBehaviour
{

    public InformationCanvas _canvas;
    public string words;
    private const string MiniGameSceneName = "WaterHeaterMiniGame";


    private InteractWithObject _interact;
    private InventoryHelper _inventory;

    public UIElement theGUI;
    public GameObject Spot;

    public GameObject Heater;
    private Item MustardWater;
    private Item FilledWater;

    private GameObject canvi;
    private GameObject camera;
    private GameObject sunlight;
    public GameObject levelMusic;
    public GameObject waterMusic;


    void Start()
    {
        _interact = GetComponent<InteractWithObject>();
        _inventory = Systems.Inventory;

        Heater.SetActive(false);
        MustardWater = Resources.Load<Item>("Items/Jug");
        FilledWater = Resources.Load<Item>("Items/DirtyMustardWater");
    }

    public void Interaction()
    {
        if (_inventory.HasItem(MustardWater, 1))
        {
            SceneManager.LoadScene(MiniGameSceneName, LoadSceneMode.Additive);
            SceneManager.sceneLoaded += StartMinigame;
            _interact.enabled = false;
        }
        else
        {
            _interact.SetInteractText("Go talk to Frank about water");

        }

    }

    private void StartMinigame(Scene scn, LoadSceneMode lsm)
    {
        Systems.Status.Pause();
        SceneManager.sceneLoaded -= StartMinigame;


        (canvi = GameObject.Find("MiniGameClose")).SetActive(false);
        (camera = GameObject.Find("Main Camera")).SetActive(false);
        (sunlight = GameObject.Find("Sunlight")).SetActive(false);
        levelMusic.SetActive(false);
        waterMusic.SetActive(true);

        GameObject.Find("WaterHeaterMaster").GetComponent<WaterHeaterMaster>().OnWin += MiniGameFinished;
        GameObject.Find("WaterHeaterMaster").GetComponent<WaterHeaterMaster>().OnExit += MiniGameLeave;
    }

    private void MiniGameLeave()
    {
        SceneManager.UnloadSceneAsync(MiniGameSceneName);
        canvi.SetActive(true);
        camera.SetActive(true);
        sunlight.SetActive(true);
        levelMusic.SetActive(true);
        waterMusic.SetActive(false);
    }
    private void MiniGameFinished()
    {
        Systems.Status.UnPause();

        SceneManager.UnloadSceneAsync(MiniGameSceneName);

        Systems.Objectives.Satisfy("WATERHEATEREVENT");
        camera.SetActive(true);
        canvi.SetActive(true);
        sunlight.SetActive(true);
        levelMusic.SetActive(true);
        waterMusic.SetActive(false);


        _inventory.RemoveItem(MustardWater, 1);
        _inventory.AddItem(FilledWater, 1);

        Heater.SetActive(true);
        //_interact.Kill();

        UIManager.Instance.ToggleActive(theGUI);

        GameObject.Find("InventoryZip").GetComponent<AudioSource>().Play();

        _interact.Kill();

        Spot.SetActive(false);
        _canvas.ChangeText(words);

        //Destroy(gameObject);
        //Destroy(this);
    }
}
