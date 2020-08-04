using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PitLatrineInteraction : MonoBehaviour
{

    //public InformationCanvas _canvas;
    //public string words;
    //private const string MiniGameSceneName = "WaterHeaterMiniGame";


    private InteractWithObject _interact;
    private InventoryHelper _inventory;

    //public UIElement theGUI;
    //public GameObject Spot;

    //public GameObject Heater;
    private Item MustardWater;
    //private Item FilledWater;

    //private GameObject canvi;
    //private GameObject camera;
    //private GameObject sunlight;
    //public GameObject levelMusic;
    //public GameObject waterMusic;


    void Start()
    {
        _interact = GetComponent<InteractWithObject>();
        _inventory = Systems.Inventory;

        //Heater.SetActive(false);
        MustardWater = Resources.Load<Item>("Items/Jug");
        //FilledWater = Resources.Load<Item>("Items/DirtyMustardWater");
    }

    public void Interaction()
    {
        if (_inventory.HasItem(MustardWater, 1))
        {
      
            _interact.enabled = false;
        }
        else
        {
            _interact.SetInteractText(" 'Esta occupada!!' ");

        }

    }

}
