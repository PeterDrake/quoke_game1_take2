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

    public override void Open()
    {
        //activate(true);

    }
    /*
    private int WaitForIt()
    {
        yield return new WaitForSeconds(WaitTime);
    }
    */
    private void Start()
    {
        pauseOnOpen = true;
        locked = true;



        initialize();
        //WaitForIt();
        //activate(false);

    }

    private void initialize() //Get all references that are needed to populate the dialogue UI
    {
        Transform main = transform.Find("SegueToggler");
        toggler = main.gameObject;
        //ExitButton.onClick.AddListener(UIManager.Instance.ActivatePrevious);
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