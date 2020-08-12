using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompostingMaster : MonoBehaviour
{
    public GameObject cube;
    public GameObject box;
    public GameObject carbon;
    public GameObject circle;
    public InformationCanvas _interact;
 
    private Item wood;
    private Item mulch;
    private Item paper;
    public bool made;

    // Start is called before the first frame update
    void Start()
    {
        wood = Resources.Load<Item>("Items/Wood");
        mulch = Resources.Load<Item>("Items/Mulch");
        paper = Resources.Load<Item>("Items/ShreddedPaper");
        
    }

    public void BuildBox()
    {
        if (!made)
        {
            if (Systems.Inventory.HasItem(wood, 1))
            {
                Systems.Inventory.RemoveItem(wood, 1);
                box.SetActive(true);
                made = true;
                cube.transform.position = new Vector3(cube.transform.position.x, .5f, cube.transform.position.z);
                cube.GetComponent<InteractWithObject>().SetInteractText("Press 'E' to add carbon material to box");

            }
            else
            {
                cube.GetComponent<InteractWithObject>().SetInteractText("You need to gather some wood");
            }
        }
    }

    public void AddCarbon()
    {
        if (made)
        {
            if (Systems.Inventory.HasItem(mulch, 1) && Systems.Inventory.HasItem(paper, 1))
            {
                carbon.SetActive(true);
                Systems.Objectives.Satisfy("COMPOSTFINISHED");
                Systems.Inventory.RemoveItem(mulch, 1);
                Systems.Inventory.RemoveItem(paper, 1);
                _interact.ToggleVisibility(false);
                circle.SetActive(false);
                Destroy(cube);
            }
            else
            {
                cube.GetComponent<InteractWithObject>().SetInteractText("You need to gather more carbon material");
            }
        }
    }


    public void SwapText()
    {
        if (!made)
        {
            cube.GetComponent<InteractWithObject>().SetInteractText("Press 'E' to build a box");
        }
        else
        {
            cube.GetComponent<InteractWithObject>().SetInteractText("Press 'E' to add carbon material to box");

        }
    }
        
}
