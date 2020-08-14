using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroToCorgiSaveMiniGame : MonoBehaviour
{
    public GameObject CompostingToilet;
    public GameObject InTheMeantimeCanvas;
    public GameObject MiniGameClose;
    public GameObject VideoDisplayer;
    public GameObject VideoBackground;
    public GameObject Video;
    public GameObject TsuPointer;

    public InformationCanvas _canvas;

    private bool check;
    private StartDialogue script;

    void Start()
    {
        script = GameObject.Find("Controller").GetComponent<StartDialogue>();
    }


//check if the sanitation is built
    void Update()
    {
        if (CompostingToilet.activeSelf && !check)
        {
            StartCoroutine(nameof(StartCutScene));
            check = true; //used this bool so the coroutine is triggered only once
        }
    }
    
    private IEnumerator StartCutScene()
    {
        //if the sanitation is built, wait for four seconds and trigger "In the meantime..." slide
        yield return new WaitForSeconds(1.5f);
        MiniGameClose.SetActive(false);
        InTheMeantimeCanvas.SetActive(true);
        
        //then trigger the video
        yield return new WaitForSeconds(3f);
        VideoBackground.SetActive(true);
        VideoDisplayer.SetActive(true);
        Video.SetActive(true);
        InTheMeantimeCanvas.SetActive(false);
        yield return new WaitForSeconds(63f);
        
        //turn off the video
        VideoBackground.SetActive(false);
        VideoDisplayer.SetActive(false);
        Video.SetActive(false);
        MiniGameClose.SetActive(true);
        
        //change banner to "Look for Tsu"
        _canvas. ChangeText("Look for Tsu");
        
        //start Tsu's dialogue
        StartCoroutine(nameof(TsuDialogue));
    }

    private IEnumerator TsuDialogue()
    {
        yield return new WaitForSeconds(3f);
        
        //Tsu's dialogue appears
        script.Interact();
        
        //Tsu's dot appears
        TsuPointer.SetActive(true);
    }
    
    
}
