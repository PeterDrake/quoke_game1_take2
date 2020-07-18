using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BarrelVisit : MonoBehaviour
{
    /*private const string MiniGameSceneName = "WaterBucketsMiniGame";


    private InteractWithObject _interact;
    private InventoryHelper _inventory;

    public GameObject Barrel;


    private byte Conditions;


    private GameObject canvi;
    private GameObject camera;
    private GameObject vcam;
    private GameObject sunlight;
    //private GameObject levelAudio;

    private void Awake()
    {
        Barrel.SetActive(true);
    }

    void Start()
    {
        _interact = GetComponent<InteractWithObject>();
        _inventory = Systems.Inventory;

        Bucket = Resources.Load<Item>("Items/Bucket");
        Bag = Resources.Load<Item>("Items/Bag");
        Sawdust = Resources.Load<Item>("Items/Sawdust");
        Sanitizer = Resources.Load<Item>("Items/Sanitizer");
        ToiletPaper = Resources.Load<Item>("Items/ToiletPaper");
        _inventory.CheckOnAdd.AddListener(UpdateConditions);

        Buckets.SetActive(false);
    }

    public void Interaction()
    {
        if ((Conditions ^ 0xF) == 0)
        {
            SceneManager.LoadScene(MiniGameSceneName, LoadSceneMode.Additive);
            SceneManager.sceneLoaded += StartMinigame;
            _interact.enabled = false;
        }
        else
        {
            _interact.SetInteractText("You need to gather more items");
        }
    }
    //CAMERA, ui, move stage up a lot
    private void UpdateConditions() //called every time an item is added to the inventory 
    {
        if ((Conditions ^ 0xF) == 0) return;

        if ((Conditions & 0x1) > 0 || _inventory.HasItem(Bucket, 2)) //first condition not met
            Conditions |= 0x1;

        if ((Conditions & 0x2) > 0 || _inventory.HasItem(Bag, 1)) //second condition not met
            Conditions |= 0x2;

        if ((Conditions & 0x4) > 0 || _inventory.HasItem(Sawdust, 1)) //third condition not met
            Conditions |= 0x4;

        if ((Conditions & 0x8) > 0 || _inventory.HasItem(Sanitizer, 1)) //fourth condition not met
            Conditions |= 0x8;
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

        GameObject.Find("MinigameMaster").GetComponent<MiniGameMaster>().OnWin += MiniGameFinished;
        GameObject.Find("MinigameMaster").GetComponent<MiniGameMaster>().OnExit += MiniGameLeave;
    }

    private void MiniGameLeave()
    {
        SceneManager.UnloadSceneAsync(MiniGameSceneName);
        canvi.SetActive(true);
        camera.SetActive(true);
        vcam.SetActive(true);
        sunlight.SetActive(true);
        //levelAudio.SetActive(true);
        _interact.enabled = true;
    }
    private void MiniGameFinished()//this is not getting called
    {
        Systems.Status.UnPause();

        SceneManager.UnloadSceneAsync(MiniGameSceneName);

        Systems.Objectives.Satisfy("TOILETEVENT");
        camera.SetActive(true);
        vcam.SetActive(true);
        canvi.SetActive(true);
        sunlight.SetActive(true);
        //levelAudio.SetActive(true);

        _inventory.RemoveItem(Bucket, 2);
        _inventory.RemoveItem(Bag, 1);
        _inventory.RemoveItem(Sawdust, 1);
        // _inventory.RemoveItem( Sanitizer, 1);
        // _inventory.RemoveItem( ToiletPaper, 1);

        Buckets.SetActive(true);
        Destroy(gameObject);
        Destroy(this);
    }*/
}
