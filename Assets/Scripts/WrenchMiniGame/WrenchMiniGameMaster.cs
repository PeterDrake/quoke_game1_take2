using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class WrenchMiniGameMaster : MonoBehaviour
{

    public GameObject Win;
    
    public UnityAction OnWin;

    public UnityAction OnExit;

    
    public void CheckCorrect(bool Turned)
    {
        if (Turned)
        {
            Debug.Log("Congratz, you have won!");
            Win.SetActive(true);
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
