
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DialogueDisplayer : UIElement
{

    public delegate string DialogueEvent();
    
    private const byte requiredComponentsAmount = 8;
    // option1, option2, invalid1, invalid2, npcImage, npcSpeech, npcName, exit 
    
    private DialogueNode activeDialogue;
    
    private DialogueEvent option1;
    private DialogueEvent option2;
    private DialogueEvent exit;
    private bool displaying;
    public GameObject toggler;
    
    // Object references for population of information
    private Image npcImage;
    private Text npcSpeech;
    private Text npcName;
    
    private Text optionOne;
    private Text optionTwo;
    [SerializeField] private GameObject responseOneEnabler;
    [SerializeField] private GameObject responseTwoEnabler;
    [SerializeField] private GameObject bye;

    private Text invalidOne;
    private Text invalidTwo;
    private GameObject invalidOneEnabler;
    private GameObject invalidTwoEnabler;

    private MenuDisplayer menu;
    private Button dialog1;
    private Button dialog2;
    private Button dialogEnd;
    
    private void Awake()
    {
        pauseOnOpen = true;
    }

    public override void Close()
    {
        activate(false);
    }

    public override void Open()
    {
        activate(true);
    }

    public void Load(DialogueNode d, NPC n)
    {
        print("new dialog select");
        // Debug.Log("Loading "+d.name+", "+n.name);
        npcName.text = n.name;
        if (n.image != null) npcImage.sprite = n.image;
        npcSpeech.text = d.speech;

        dialog1 = responseOneEnabler.GetComponent<Button>();
        dialog2 = responseTwoEnabler.GetComponent<Button>();
        dialogEnd = bye.GetComponent<Button>();


        ////one dialog node
        //if (d.GetNodeOne() != null && d.GetNodeTwo() == null)
        //{
        //    EventSystem.current.SetSelectedGameObject(responseOneEnabler);
        //    //set navigation for one dialog node to exit button
        //    Navigation nav = dialog1.navigation;
        //    nav.mode = Navigation.Mode.Explicit;
        //    nav.selectOnDown = dialogEnd;
        //    nav.selectOnUp = dialogEnd;
        //    dialog1.navigation = nav;
        //    //set navigation for exit to one dialog button
        //    nav = dialogEnd.navigation;
        //    nav.mode = Navigation.Mode.Explicit;
        //    nav.selectOnDown = dialog1;
        //    nav.selectOnUp = dialog1;
        //    dialogEnd.navigation = nav;
        //}

        ////two dialog node
        //if (d.GetNodeOne() != null && d.GetNodeTwo() != null)
        //{
        //    EventSystem.current.SetSelectedGameObject(responseOneEnabler);
        //    //set navigation for one dialog node to up->end, down->two
        //    Navigation nav = dialog1.navigation;
        //    nav.mode = Navigation.Mode.Explicit;
        //    nav.selectOnDown = dialog2;
        //    nav.selectOnUp = dialogEnd;
        //    dialog1.navigation = nav;
        //    //set navigation for two dialog node to up->one, down->end
        //    nav = dialog2.navigation;
        //    nav.mode = Navigation.Mode.Explicit;
        //    nav.selectOnDown = dialogEnd;
        //    nav.selectOnUp = dialog1;
        //    dialog2.navigation = nav;
        //    //set navigation for exit to up->two, down->one
        //    nav = dialogEnd.navigation;
        //    nav.mode = Navigation.Mode.Explicit;
        //    nav.selectOnDown = dialog1;
        //    nav.selectOnUp = dialog2;
        //    dialogEnd.navigation = nav;
        //}

        ////no dialog node
        //if (d.GetNodeOne() == null && d.GetNodeTwo() == null)
        //{
        //    EventSystem.current.SetSelectedGameObject(bye);
        //    //set navigation for exit only;
        //    Navigation nav = dialog1.navigation;
        //    nav.mode = Navigation.Mode.None;
        //}

        UIManager.Instance.SetAsActive(this);
        /* Extra:
            check each options requirements, and enable invalids accordingly
        */
    }

    public void LinkEvents(DialogueEvent option1, DialogueEvent option2, DialogueEvent exit)
    {
        this.option1 = option1;
        this.option2 = option2;
        this.exit = exit;
    }

    public Tuple<bool, bool> ActiveOptions()
    {
        if (!displaying) return new Tuple<bool, bool>(false, false);
        return new Tuple<bool, bool>(activeDialogue.GetTextOne() != null, activeDialogue.GetTextTwo() != null);
    }

    private void Start()
    {
        locked = true;
        menu = GameObject.Find("Basic Pause Menu").GetComponent<MenuDisplayer>();
        initialize();
        activate(false);   
    }
        
    private void initialize() //Get all references that are needed to populate the dialogue UI
    {
        byte componentsFound = 0;
        Transform main = transform.Find("DialogueToggler");
        toggler = main.gameObject;
        
        foreach (Transform child in main)
        {
            switch (child.name)
            {
                case "invalid1":
                    invalidOneEnabler = child.gameObject;
                    invalidOne = child.Find("text").GetComponent<Text>();
                    componentsFound += 1;
                    break;
                case "invalid2":
                    invalidTwoEnabler = child.gameObject;
                    invalidTwo = child.Find("text").GetComponent<Text>();
                    componentsFound += 1;
                    break;
                case "name":
                    npcName = child.GetComponent<Text>();
                    componentsFound += 1;
                    break;
                case "speech":
                    npcSpeech = child.GetComponent<Text>();
                    componentsFound += 1;
                    break;
                case "image":
                    npcImage = child.GetComponent<Image>();
                    componentsFound += 1;
                    break;
                case "option1":
                    child.GetComponent<Button>().onClick.AddListener(optionOnePressed);
                    optionOne = child.Find("text").GetComponent<Text>();
                    responseOneEnabler = child.gameObject;
                    componentsFound += 1;
                    break;
                case "option2":
                    child.GetComponent<Button>().onClick.AddListener(optionTwoPressed);
                    optionTwo = child.Find("text").GetComponent<Text>();
                    responseTwoEnabler = child.gameObject;
                    componentsFound += 1;
                    break;
                case "exit":
                    bye = child.gameObject;
                    child.GetComponent<Button>().onClick.AddListener(exitPressed);
                    componentsFound += 1;
                    break;
            }
        }
        if (componentsFound != requiredComponentsAmount) 
            throw new Exception("Required Components for Dialogue Displayer were not found!");
    }

    // Called when the first dialogue option is pressed
    public void optionOnePressed()
    {
        string resp = option1();
        
        if (resp != "")
        {
            invalidOneEnabler.SetActive(true);
            invalidOne.text = resp;
        }
    }
    
    // Called when the second dialogue option is pressed
    public void optionTwoPressed()
    {
        string resp = option2();
        
        if (resp != "")
        {
            invalidTwoEnabler.SetActive(true);
            invalidTwo.text = resp;
        }
    }

    public void exitPressed()
    {
        UIManager.Instance.ActivatePrevious();
        exit();
    }

    private void activate(bool active)
    {
        toggler.SetActive(active);
        if (active) { menu.openedCanvi(this); }
        else { menu.closedCanvi(); }
    }
}


//514F5E
//6CAEE7
//print("registered keys");
//Systems.Input.RegisterKey("down", delegate
//        {
//            if (!second)
//            {

//                nextOption = selectedOption;
//                selectedOption = lastOption;
//                lastOption = nextOption;
//            }
//            else
//            {
//                GameObject s = selectedOption;
//selectedOption = nextOption;
//                nextOption = lastOption;
//                lastOption = s;
//            }
//            print("PRESS DOWN KEY " + "select= " + selectedOption.name + " next= " + nextOption.name + " last= " + lastOption.name);
//        });

//        Systems.Input.RegisterKey("up", delegate
//        {
//            if (!second)
//            {
//                nextOption = selectedOption;
//                selectedOption = lastOption;
//                lastOption = nextOption;
//            }
//            else
//            {
//                GameObject s = selectedOption;
//selectedOption = lastOption;
//                lastOption = nextOption;
//                nextOption = s;
//            }
//            print("PRESS UP KEY " + "select= " + selectedOption.name + " next= " + nextOption.name + " last= " + lastOption.name);
//        });