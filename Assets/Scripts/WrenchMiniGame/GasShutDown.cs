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
    
    private byte Conditions; //Condition is 0
    
    private GameObject canvi;
    private GameObject camera;
    private GameObject levelAudio;

    void Start()
    {
        _interact = GetComponent<InteractWithObject>();
        _inventory = Systems.Inventory;
        
       Wrench =  Resources.Load<Item>("Items/Wrench");
       _inventory.CheckOnAdd.AddListener(UpdateConditions);
        
    }
    
    public void Interaction()
    {
        if ((Conditions ^ 0x1) == 0)
        {
            SceneManager.LoadScene(MiniGameSceneName, LoadSceneMode.Additive);
            SceneManager.sceneLoaded += StartMinigame;
            _interact.enabled = false;
        }
        else
        {
            _interact.SetInteractText("You need to get the wrench!");
        }
    }
    //CAMERA, ui, move stage up a lot
    private void UpdateConditions() //called every time an item is added to the inventory 
    {
        if ((Conditions ^ 0x1) == 0) return;

        if ((Conditions & 0x1) > 0 || _inventory.HasItem(Wrench, 1)) //first condition not met
            Conditions |= 0x1;
    } 

    private void StartMinigame(Scene scn, LoadSceneMode lsm)
    {
        Systems.Status.Pause();
        SceneManager.sceneLoaded -= StartMinigame;


        (canvi = GameObject.Find("Canvi")).SetActive(false);
        (camera = GameObject.Find("Main Camera")).SetActive(false);
        (levelAudio = GameObject.Find("Audio")).SetActive(false);

        GameObject.Find("GasMaster").GetComponent<WrenchMiniGameMaster>().OnWin += MiniGameFinished;
        GameObject.Find("GasMaster").GetComponent<WrenchMiniGameMaster>().OnExit += MiniGameLeave;
    }

    private void MiniGameLeave()
    {
        SceneManager.UnloadSceneAsync(MiniGameSceneName);
        canvi.SetActive(true);
        camera.SetActive(true);
        levelAudio.SetActive(true);
    }
    private void MiniGameFinished()
    {
        Systems.Status.UnPause();

        SceneManager.UnloadSceneAsync(MiniGameSceneName);
        canvi.SetActive(true);
        
        //Systems.Objectives.Satisfy("TOILETEVENT");
        camera.SetActive(true);
        canvi.SetActive(true);
        levelAudio.SetActive(true);

        //_inventory.RemoveItem(Wrench, 1);
       
    }
}
