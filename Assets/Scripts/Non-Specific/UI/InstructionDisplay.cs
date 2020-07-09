using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class InstructionDisplay : UIElement
{


    private GameObject toggler;
    public Button ExitButton;

    private MenuDisplayer menu;

    public override void Open()
    {
        activate(true);
    }

    private void Start()
    {
        pauseOnOpen = true;
        locked = true;

        menu = GameObject.Find("Basic Pause Menu").GetComponent<MenuDisplayer>();

        initialize();
        activate(false);
        
    }

    private void initialize() //Get all references that are needed to populate the UI
    {
        Transform main = transform.Find("InstructToggler");
        toggler = main.gameObject;

        //ActivatePrevious would reactivate the menu if it had been pulled up, 
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
        if (active) { menu.openedCanvi(this); }
        else { menu.closedCanvi(); }
    }


}
