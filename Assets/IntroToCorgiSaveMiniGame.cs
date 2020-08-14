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
    
    public InformationCanvas _canvas;

    private bool check;
    
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
        yield return new WaitForSeconds(4f);
        MiniGameClose.SetActive(false);
        InTheMeantimeCanvas.SetActive(true);
        
        //then trigger the video
        yield return new WaitForSeconds(3f);
        VideoBackground.SetActive(true);
        VideoDisplayer.SetActive(true);
        Video.SetActive(true);
        yield return new WaitForSeconds(63f);
        
        //turn off the video
        VideoBackground.SetActive(false);
        VideoDisplayer.SetActive(false);
        Video.SetActive(false);
        MiniGameClose.SetActive(true);
        
        //change banner to "Look for Tsu"
        _canvas. ChangeText("Look for Tsu");
    }
}
