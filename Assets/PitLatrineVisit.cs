using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PitLatrineVisit : MonoBehaviour
{
    private const string MiniGameSceneName = "PitLatrineMiniGame";


    private InteractWithObject _interact;
    private InventoryHelper _inventory;

    public GameObject Place1;
    public GameObject Player;
    private Item Shovel;

    private GameObject canvi;
    private GameObject camera;
    private GameObject sunlight;

    void Start()
    {
        _interact = GetComponent<InteractWithObject>();
        _inventory = Systems.Inventory;

        //Place1.SetActive(false);
        //Shovel = Resources.Load<Item>("Items/Shovel");
    }

    public void Interaction()
    {
        //if (_inventory.HasItem(Shovel, 1))
        //{
            SceneManager.LoadScene(MiniGameSceneName, LoadSceneMode.Additive);
            SceneManager.sceneLoaded += StartMinigame;
            _interact.enabled = false;
            Place1.SetActive(false);
            Player.SetActive(false);
        //}
        //else
        //{
        //    _interact.SetInteractText("Go talk to Frank about sanitation");

        //}

    }

    private void StartMinigame(Scene scn, LoadSceneMode lsm)
    {
        Systems.Status.Pause();
        SceneManager.sceneLoaded -= StartMinigame;


        (canvi = GameObject.Find("Canvi")).SetActive(false);
        (camera = GameObject.Find("Main Camera")).SetActive(false);
        (sunlight = GameObject.Find("Sunlight")).SetActive(false);

        GameObject.Find("MiniGameMasterPitLatrine").GetComponent<MiniGameMasterPitLatrine>().OnWin += MiniGameFinished;
        GameObject.Find("MiniGameMasterPitLatrine").GetComponent<MiniGameMasterPitLatrine>().OnExit += MiniGameLeave;
    }

    private void MiniGameLeave()
    {
        SceneManager.UnloadSceneAsync(MiniGameSceneName);
        canvi.SetActive(true);
        camera.SetActive(true);
        sunlight.SetActive(true);
        Place1.SetActive(true);
        Player.SetActive(true);
    }
    private void MiniGameFinished()
    {
        Place1.SetActive(true);
        Player.SetActive(true);
        Systems.Status.UnPause();

        SceneManager.UnloadSceneAsync(MiniGameSceneName);
        

        Systems.Objectives.Satisfy("PITLATRINEEVENT");
        camera.SetActive(true);
        canvi.SetActive(true);
        sunlight.SetActive(true);

        //_inventory.RemoveItem(Shovel, 1);

        //WaterPond.SetActive(true); this is for the water pond
        _interact.Kill();

        //Destroy(gameObject);
        //Destroy(this);
    }
}
