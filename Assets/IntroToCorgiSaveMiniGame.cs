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
    private StatusManager script;
    private float Warmth;

    void Start()
    {
        script = GameObject.Find("Managers").GetComponent<StatusManager>();
        Warmth = script.Warmth;
        Debug.Log("Warmth is " + Warmth);
    }


//check if the sanitation is built
    void Update()
    {
        if (Warmth >= 90f)
        {
            Debug.Log("WARMTH IS WELL");
            if (CompostingToilet.activeSelf)
            {
                Debug.Log("BOTH ARE WELL");
                if (!check)
                {
                    Debug.Log("ALL IS WELL");
                }
            }
        }
        if (CompostingToilet.activeSelf && !check) //&& Warmth>=90f)
        {
            StartCoroutine(nameof(StartCutScene));
            check = true; //used this bool so the coroutine is triggered only once
        }
    }
    
    private IEnumerator StartCutScene()
    {
        //if the sanitation is built, wait for four seconds and trigger "In the meantime..." slide
        //yield return new WaitForSeconds(4f);
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
    }
}
