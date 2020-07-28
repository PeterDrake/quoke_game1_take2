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

    private int check=0;
    private InteractWithObject script;

    // Start is called before the first frame update
    void Start()
    {
        script = BarrelWithWater.GetComponent<InteractWithObject>();
    }

    public void FillPotWithWater()
    {
        Systems.Inventory.RemoveItem(Pot, 1);
        Systems.Inventory.AddItem(PotWithWater, 1);
        Sphere.SetActive(true);
        Particles.SetActive(true);
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
