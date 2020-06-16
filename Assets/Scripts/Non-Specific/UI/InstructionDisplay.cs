using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class InstructionDisplay : UIElement
{

    //[Header("A prefab object which will be instantiated for each slot in the inventory")]


    public override void Open()
    {
    }

    private void Load(Item[] items, byte[] amounts)
    {
        activate(true);
        
    }

    private void Start()
    {
        pauseOnOpen = true;
        locked = true;

        

        initialize();
        activate(false);
        
    }

    private void initialize() //Get all references that are needed to populate the dialogue UI
    {
        Transform main = transform.Find("InstructToggler");
        //toggler = main.gameObject;
        byte componentsFound = 1;

        /*foreach (Transform child in main)
        {
            switch (child.name)
            {
                case "itemPanel":
                    componentsFound += 1;
                    for (int i = 0; i < capacity; i++)
                    {
                        GameObject inst = Instantiate(SlotPrefab, child);
                        itemSlots[i] = inst.transform.Find("icon").GetComponent<Image>();

                        int k = i;
                        inst.GetComponent<Button>().onClick.AddListener(delegate { setActiveItem(k); });
                    }
                    break;
                case "displayImage":
                    componentsFound += 1;
                    displayImage = child.GetComponent<Image>();
                    break;
                case "displayAmount":
                    componentsFound += 1;
                    displayAmount = child.GetComponent<Text>();
                    break;
                case "description":
                    componentsFound += 1;
                    description = child.GetComponent<Text>();
                    break;
                case "displayName":
                    componentsFound += 1;
                    displayName = child.GetComponent<Text>();
                    break;
                case "exitButton":
                    componentsFound += 1;
                    child.GetComponent<Button>().onClick.AddListener(UIManager.Instance.ActivatePrevious);
                    break;
                case "useToggler":
                    componentsFound += 3;
                    useToggle = child.gameObject;
                    Transform button = child.Find("use");
                    button.GetComponent<Button>().onClick.AddListener(useSelectedItem);
                    useText = button.Find("text").GetComponent<Text>();
                    break;
                case "openToggler":
                    componentsFound += 3;
                    openToggle = child.gameObject;
                    Transform button2 = child.Find("open");
                    openText = button2.Find("text").GetComponent<Text>();
                    break;
            }
        }
        if (componentsFound != requiredComponentsAmount)
            throw new Exception("Required Components for Dialogue Displayer were not found!");*/
    }
    /*private void setActiveItem(int i)
    {
        if (items[i] == null) return;

        selectedItem = i;

        displayImage.sprite = items[i].DisplayImage;
        displayName.text = items[i].DisplayName;
        description.text = items[i].Description;
        displayAmount.text = amounts[i].ToString();

        if (items[i].ID == "PAM")
        {
            useToggle.SetActive(false);
            openToggle.SetActive(true);
            openText.text = "Open Pamphlet";

        }

        else if (items[i].action != null)
        {
            openToggle.SetActive(false);
            useToggle.SetActive(true);
            useText.text = items[i].action.ActionWord;
        }
        else
        {
            useToggle.SetActive(false);
            openToggle.SetActive(false);
        }
    }*/

    public override void Close()
    {
        activate(false);
    }

    private void activate(bool active)
    {
        //toggler.SetActive(active);
    }

    /*private void useSelectedItem()
    {
        items[selectedItem].action.Use(ref items[selectedItem]);
        UIManager.Instance.SetAsActive(this);
    }*/

}
