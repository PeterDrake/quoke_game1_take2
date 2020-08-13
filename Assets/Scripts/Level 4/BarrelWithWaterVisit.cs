using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BarrelWithWaterVisit : MonoBehaviour
{

    public GameObject BoilWater;

    private InteractWithObject _interact;
    private InventoryHelper _inventory;


    
    private Item Pot;
    private Item Wood;



    void Start()
    {
        _interact = GetComponent<InteractWithObject>();
        _inventory = Systems.Inventory;

        
        Pot = Resources.Load<Item>("Items/Pot");
        Wood = Resources.Load<Item>("Items/Wood");
    }

    public void Interaction()
    {
        if (_inventory.HasItem(Pot, 1) && _inventory.HasItem(Wood, 1))
        {

            _interact.enabled = false;
            BoilWater.SetActive(true);

        }
        else
        {
            _interact.SetInteractText("Go talk to Ahmad about water");
            BoilWater.SetActive(false);

        }

    }
}
