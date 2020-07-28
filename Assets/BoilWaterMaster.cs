using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoilWaterMaster : MonoBehaviour
{
    public Item Wood;
    public GameObject Sphere;
    public GameObject Particles;

    private int check=0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Systems.Inventory.HasItem(Wood, 1)&& check==0)
        {
            Sphere.SetActive(true);
            Particles.SetActive(true);
            check = 1;
        }
    }
}
