
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

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

    public GameObject lastOption;
    public GameObject selectedOption;
    public GameObject nextOption;
    
    public bool second;

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

        //one dialog node
        if (d.GetNodeOne() != null && d.GetNodeTwo() == null)
        {
            second = false;

            selectedOption = responseOneEnabler;
            nextOption = bye;
            lastOption = bye;

            responseOneEnabler.SetActive(true);
            optionOne.text = d.GetTextOne();
            responseTwoEnabler.SetActive(false);
            optionTwo.text = d.GetTextTwo();
        }

        //two dialog node
        if (d.GetNodeOne() != null && d.GetNodeTwo() != null)
        {
            second = true;

            selectedOption = responseOneEnabler;
            nextOption = responseTwoEnabler;
            lastOption = bye;

            responseOneEnabler.SetActive(true);
            optionOne.text = d.GetTextOne();
            responseTwoEnabler.SetActive(true);
            optionTwo.text = d.GetTextTwo();
        }

        //no dialog node
        if (d.GetNodeOne() == null && d.GetNodeTwo() == null)
        {

            second = false;

            selectedOption = bye;
            nextOption = bye;
            lastOption = bye;

            responseOneEnabler.SetActive(false);
            optionOne.text = d.GetTextOne();
            responseTwoEnabler.SetActive(false);
            optionTwo.text = d.GetTextTwo();
        }

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
        print("add keys here");
        Systems.Input.RegisterKey("down", delegate
        {
            if (toggler.activeInHierarchy)
            {
                if (!second)
                {

                   nextOption = selectedOption;
                    selectedOption = lastOption;
                    lastOption = nextOption;
                }
                else
                {
                    GameObject s = selectedOption;
                    selectedOption = nextOption;
                    nextOption = lastOption;
                    lastOption = s;
                }
            }
            //print("PRESS DOWN KEY " + "select= " + displayer.selectedOption.name + " next= " + displayer.nextOption.name + " last= " + displayer.lastOption.name);
        });

        Systems.Input.RegisterKey("up", delegate
        {
            if (toggler.activeInHierarchy)
            {
                if (!second)
                {
                    nextOption = selectedOption;
                    selectedOption = lastOption;
                    lastOption = nextOption;
                }
                else
                {
                    GameObject s = selectedOption;
                    selectedOption = lastOption;
                    lastOption = nextOption;
                   nextOption = s;
                }
                //print("PRESS UP KEY " + "select= " + displayer.selectedOption.name + " next= " + displayer.nextOption.name + " last= " + displayer.lastOption.name);
            }
        });

        Systems.Input.RegisterKey("return", delegate
        {
            if (toggler.activeInHierarchy)
            {
                //if (selectedOption.name == "option1")
                //{
                //    optionOnePressed();
                //    print("PRESSED Return : selected " + selectedOption);
                //}
                //if (selectedOption.name == "option2")
                //{
                //    optionTwoPressed();
                //    print("PRESSED return : selected " + selectedOption);
                //}
                //if (selectedOption.name == "exit")
                //{
                //    exitPressed();
                //    print("PRESSED return : selected " + selectedOption);
                //}
                selectedOption.GetComponent<Button>().onClick.Invoke();

            }
        });
        locked = true;
        second = false;
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