using System;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SegueDisplayer : UIElement
{

    //[Header("A prefab object which will be instantiated for each slot in the inventory")]

    private GameObject toggler;
    public Button ExitButton;
    //public float WaitTime;


    /*
    private int WaitForIt()
    {
        yield return new WaitForSeconds(WaitTime);
    }
    */
    private void Start()
    {
        locked = true;
        pauseOnOpen = true;
        print("pasued at start");
        UIManager.Instance.Initialize(this);

        initialize();
        activate(true);
        //WaitForIt();
        //activate(false);
        
    }

    private void initialize() //Get all references that are needed to populate the dialogue UI
    {
        Transform main = transform.Find("SegueToggler");
        toggler = main.gameObject;
        UIManager.Instance.SetAsActive(this);
        ExitButton.onClick.AddListener(delegate
        { UIManager.Instance.ToggleActive(this); });
        print("initialized exit button is toggle active");
        //ExitButton.onClick.AddListener(UIManager.Instance.ActivatePrevious);
        //byte componentsFound = 1;
    }

    public override void Open()
    {
        print("open segue");
        activate(true);
    }

    public override void Close()
    {
        print("clsoed segue");
        activate(false);

    }

    private void activate(bool active)
    {
        toggler.SetActive(active);
        print("set active something");
    }


}