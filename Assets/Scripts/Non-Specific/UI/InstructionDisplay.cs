using System;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InstructionDisplay : UIElement
{


    private GameObject toggler;
    public GameObject page1;
    public GameObject page2;

    public GameObject close1;
    public GameObject close2;
    public GameObject next;
    public GameObject back;

    private MenuDisplayer menu;


    private void Start()
    {
        locked = true;
        pauseOnOpen = true;

        menu = GameObject.Find("Basic Pause Menu").GetComponent<MenuDisplayer>();
        close1.GetComponent<Button>().onClick.AddListener(delegate
        { UIManager.Instance.ToggleActive(this);});
        close2.GetComponent<Button>().onClick.AddListener(delegate
        { UIManager.Instance.ToggleActive(this);});

        Systems.Input.RegisterKey("h", delegate
        {
            UIManager.Instance.ToggleActive(this);
        });
        initialize();
        toggler.SetActive(false);

    }


    private void initialize() //Get all references that are needed to populate the UI
    {
        Transform main = transform.Find("InstructToggler");
        toggler = main.gameObject;

        //ActivatePrevious would reactivate the menu if it had been pulled up, 
        //ExitButton.onClick.AddListener(UIManager.Instance.ActivatePrevious);
        //byte componentsFound = 1;
    }

    public override void Open()
    {
        activate(true);
    }

    public override void Close()
    {
        EventSystem.current.SetSelectedGameObject(null);
        activate(false);
    }

    private void activate(bool active)
    {
        if (active)
        {
            toggler.SetActive(true);
            page1.SetActive(true);
            page2.SetActive(false);
            EventSystem.current.SetSelectedGameObject(null);
            EventSystem.current.SetSelectedGameObject(next.gameObject);
            menu.openedCanvi(this);
        }
        else
        {
            toggler.SetActive(false);
            menu.closedCanvi();
        }
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
