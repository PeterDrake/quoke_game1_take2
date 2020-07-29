using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MiniGameMaster : MonoBehaviour
{

    public bool PeeBucket;

    public bool PooBucket;

    public bool PlasticBag;

    public bool Poop;

    public bool ToiletPaper;

    public bool Sawdust;

    public bool Pee;
    
    public GameObject Win;

    //public GameObject WinSound;

    public GameObject Wrong;
    
    public UnityAction OnWin;

    public UnityAction OnExit;

    private LogToServer logger;

    public void Start()
    {
        logger = GameObject.Find("Logger").GetComponent<LogToServer>();
        logger.sendToLog("Began toilet minigame");
        Debug.Log("Began toilet minigame");
    }

    public void CheckCorrect()
    {
        if (PeeBucket && PooBucket && PlasticBag && Poop && ToiletPaper && Sawdust && Pee)
        {
            Debug.Log("Won toilet mini game");
            logger.sendToLog("Won toilet mini game");
            Win.SetActive(true);
            GameObject.Find("Sanitation Spot").GetComponent<SanitationBuilt>().MiniGameWon();
        }
        else
        {
            StartCoroutine(TryAgain());
        }
    }

    public void Leave()
    {
        OnExit.Invoke();
    }

    public IEnumerator TryAgain()
    {
        Debug.Log("Attempted to sanitize hands");
        logger.sendToLog("Attempted to sanitize hands");
        Wrong.SetActive(true);
        yield return new WaitForSeconds(3f);
        Wrong.SetActive(false);
    }

    public void WinLeave()
    {
        OnWin.Invoke();
    }

    
    
}
