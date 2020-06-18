using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class WrenchMiniGameMaster : MonoBehaviour
{

    public GameObject WinScreen;
    
    public UnityAction OnWin;

    public UnityAction OnExit;

    
    public void CheckCorrect(bool Turned)
    {
        if (Turned)
        {
            Debug.Log("Congratz, you have won!");
            WinScreen.SetActive(true);
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
