using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoilWaterMaster : MonoBehaviour
{
    public Item Wood;
    public Item Pot;
    public Item PotWithWater;

    public GameObject BarrelWithWater;
    public GameObject Sphere;
    public GameObject Particles;
    public GameObject Controller;
    public GameObject Pot1;
    public GameObject Firecomplex;

    private int check=0;
    private InteractWithObject script;
    private InteractWithObject script1;

    // Start is called before the first frame update
    void Start()
    {
        script = BarrelWithWater.GetComponent<InteractWithObject>();
        script1 = Controller.GetComponent<InteractWithObject>();
    }

    public void FillPotWithWater()
    {
        Systems.Inventory.RemoveItem(Pot, 1);
        Systems.Inventory.AddItem(PotWithWater, 1);
        Sphere.SetActive(true);
        Particles.SetActive(true);
    }

    public void RemoveWood()
    {
        Systems.Inventory.RemoveItem(Wood, 1);
    }

    public void RemovePotWater()
    {
        Systems.Inventory.RemoveItem(PotWithWater, 1);
        script1.enabled = false;
        //Controller.SetActive(false);
        Pot1.SetActive(true);
        Firecomplex.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Systems.Inventory.HasItem(Wood, 1)&& check==0)
        {
            script.enabled = true;
            check = 1;
        }
    }
}
