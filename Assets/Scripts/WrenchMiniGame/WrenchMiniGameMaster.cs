using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class WrenchMiniGameMaster : MonoBehaviour
{

    public GameObject WinScreen;
    public GameObject Audio;
    public GameObject WinSound;
    
    public UnityAction OnWin;

    public UnityAction OnExit;

    
    public void CheckCorrect(bool Turned)
    {
        if (Turned)
        {
            WinScreen.SetActive(true);
            Audio.SetActive(false);
            WinSound.SetActive(true);
            Debug.Log("Congratz, you have won!");

           // SceneManager.LoadScene("Level 1", LoadSceneMode.Single);
        }
        
    }

    public void Leave()
    {
        OnExit.Invoke();
    }

    public void WinLeave()
    {
        OnWin.Invoke();
    }
}
