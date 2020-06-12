using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GasShutDown : MonoBehaviour
{
    private const string MiniGameSceneName = "Gas_Value_MiniGame";
    
    
    private InteractWithObject _interact;
    private InventoryHelper _inventory;
    
    private Item Wrench;
    
    private bool HasWrench;
    
    private byte Conditions;
    
    private GameObject canvi;
    private GameObject camera;

    void Start()
    {
        _interact = GetComponent<InteractWithObject>();
        _inventory = Systems.Inventory;
        
       Wrench =  Resources.Load<Item>("Items/Wrench");
       _inventory.CheckOnAdd.AddListener(UpdateConditions);
        
    }
    
    public void Interaction()
    {
        if ((Conditions ^ 0xF) == 0)
        {
            SceneManager.LoadScene(MiniGameSceneName, LoadSceneMode.Additive);
            SceneManager.sceneLoaded += StartMinigame;
        }
        else
        {
            _interact.SetInteractText("You need to get the wrench!");
        }
    }
    //CAMERA, ui, move stage up a lot
    private void UpdateConditions() //called every time an item is added to the inventory 
    {
        if ((Conditions ^ 0xF) == 0) return;

        if ((Conditions & 0x1) > 0 || _inventory.HasItem(Wrench, 1)) //first condition not met
            Conditions |= 0x1;
    } 

    private void StartMinigame(Scene scn, LoadSceneMode lsm)
    {
        Systems.Status.Pause();
        SceneManager.sceneLoaded -= StartMinigame;


        (canvi = GameObject.Find("Canvi")).SetActive(false);
        (camera = GameObject.Find("Cameras")).SetActive(false);
        GameObject.Find("MinigameMaster").GetComponent<MiniGameMaster>().OnWin += MiniGameFinished;
        GameObject.Find("MinigameMaster").GetComponent<MiniGameMaster>().OnExit += MiniGameLeave;
    }

    private void MiniGameLeave()
    {
        SceneManager.UnloadSceneAsync(MiniGameSceneName);
        canvi.SetActive(true);
        camera.SetActive(true);
    }
    private void MiniGameFinished()//this is not getting called
    {
        Systems.Status.UnPause();

        SceneManager.UnloadSceneAsync(MiniGameSceneName);
        canvi.SetActive(true);
        
        Systems.Objectives.Satisfy("TOILETEVENT");
        camera.SetActive(true);
        canvi.SetActive(true);

        _inventory.RemoveItem(Wrench, 1);
        
        Destroy(gameObject);
        Destroy(this);
    }
}
