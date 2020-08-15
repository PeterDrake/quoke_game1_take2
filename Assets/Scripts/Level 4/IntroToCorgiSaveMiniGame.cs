using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IntroToCorgiSaveMiniGame : MonoBehaviour
{
    public GameObject CompostingToilet;
    public GameObject InTheMeantimeCanvas;
    public GameObject MiniGameClose;
    public GameObject VideoDisplayer;
    public GameObject VideoBackground;
    public GameObject Video;
    public GameObject TsuPointer;

    public GameObject Ahmad;
    public GameObject Bruce;
    public NavMeshAgent Bruce1;
    public GameObject Maria;

    public InformationCanvas _canvas;

    private bool check;
    private StartDialogue script;
    private NPCWalking scriptBruce;
    private NPCWalking scriptAhmad;
    private WayPointPatrol scriptMaria;
    private Animator animator1;

    void Start()
    {
        script = this.GetComponent<StartDialogue>();
        scriptAhmad = Ahmad.GetComponent<NPCWalking>();
        scriptBruce = Bruce.GetComponent<NPCWalking>();
        scriptMaria = Maria.GetComponent<WayPointPatrol>();
        //Bruce1 = Bruce.GetComponent<NavMeshAgent>();
        animator1 = Ahmad.GetComponent<Animator>();
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
        if (GameObject.Find("Music") != null) { GameObject.Find("Music").GetComponent<AudioSource>().Pause(); }
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
        if (GameObject.Find("Music") != null) { GameObject.Find("Music").GetComponent<AudioSource>().Play(); }
        MiniGameClose.SetActive(true);
        
        //change banner to "Look for Tsu"
        _canvas. ChangeText("Look for Tsu");
        
        yield return new WaitForSeconds(3f);
        
        //Tsu's dialogue appears
        script.Interact();
        
        //Tsu's dot appears
        if (GameObject.Find("TsuPointer") != null) { GameObject.Find("TsuPointer").GetComponent<FlatFollow>().appear(); }

        GameObject.Find("TrePointer").GetComponent<FlatFollow>().appear();
        GameObject.Find("MoPointer").GetComponent<FlatFollow>().appear();

        //Ahmad starts walking to Tsu
        scriptAhmad.enabled = true;
        scriptMaria.enabled = true;
        scriptBruce.enabled = true;
        Bruce1.enabled = true;
        
        Ahmad.GetComponent<SphereCollider>().isTrigger = false;
        Ahmad.GetComponent<InteractWithObject>().Kill();

        //Maria starts moving towards Tsu

        
        //Bruce starts walking to Tsu
        scriptBruce.enabled = true;
        Bruce1.enabled = true;
        
        
    }
    
}
