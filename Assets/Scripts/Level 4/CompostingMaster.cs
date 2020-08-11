using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompostingMaster : MonoBehaviour
{
    public GameObject box;
    public GameObject carbon;
    public GameObject script1;
    public GameObject script2;
    public GameObject circle;
    public CompostingSwapText swap;
 
    private Item wood;
    private Item mulch;
    private Item paper;




    // Start is called before the first frame update
    void Start()
    {
        wood = Resources.Load<Item>("Items/Wood");
        mulch = Resources.Load<Item>("Items/Mulch");
        paper = Resources.Load<Item>("Items/ShreddedPaper");
    }

    public void BuildBox()
    {
        if (Systems.Inventory.HasItem(wood,1))
        {
            box.SetActive(true);
            Systems.Inventory.RemoveItem(wood, 1);
            Destroy(script1);
            script2.SetActive(true);
        }
        else
        { 
            script1.GetComponent<InteractWithObject>().SetInteractText("You need to gather some wood");
        }
    }

    public void AddCarbon()
    {
        if (Systems.Inventory.HasItem(mulch,1) && Systems.Inventory.HasItem(paper, 1))
        {
            carbon.SetActive(true);
            Systems.Inventory.RemoveItem(mulch,1);
            Systems.Inventory.RemoveItem(paper, 1);
            script2.GetComponent<InteractWithObject>().SetInteractText("Press 'E' to use composting toilet");
            swap.made = true;

        }
        if (carbon.activeSelf)
        {
            UseCompostingToilet();
        }
        else
        {
            script2.GetComponent<InteractWithObject>().SetInteractText("You need to gather more carbon material");

        }
    }

    public void UseCompostingToilet()
    {
        Systems.Status.AffectRelief(100f);
    }


    //void Update()
    //{
    //    if (!box)
    //    {
    //        _
    //    }
    //}
}
