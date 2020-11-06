using System;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InstructionDisplay : UIElement
{


    private GameObject toggler;
    public Button ExitButton;
    public GameObject page1;
    public GameObject page2;

    public GameObject close1;
    public GameObject close2;
    public GameObject next;
    public GameObject back;

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
        Systems.Input.RegisterKey("h", delegate
        {
            UIManager.Instance.ToggleActive(this);
        }
           );

    }

    //private void Awake()
    //{
    //    pauseOnOpen = true;
    //}

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
        page1.SetActive(true);
        page2.SetActive(false);
        if (active)
        {
            menu.openedCanvi(this);
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(next.gameObject);
        }
        else { menu.closedCanvi(); }
    }


    public void NextPressed()
    {
        page1.SetActive(false);
        page2.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(back.gameObject);
    }

    public void BackPressed()
    {
        page2.SetActive(false);
        page1.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(next.gameObject);
    }

}
