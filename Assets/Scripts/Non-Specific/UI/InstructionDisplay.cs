using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class InstructionDisplay : UIElement
{

    //[Header("A prefab object which will be instantiated for each slot in the inventory")]

    private GameObject toggler;
    public Button ExitButton;

    public override void Open()
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
        toggler = main.gameObject;
        ExitButton.onClick.AddListener(UIManager.Instance.ActivatePrevious);
        //byte componentsFound = 1;

        
    }

    public override void Close()
    {
        activate(false);
    }

    private void activate(bool active)
    {
        
        toggler.SetActive(active);
    }


}
