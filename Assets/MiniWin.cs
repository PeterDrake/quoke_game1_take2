using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniWin : MonoBehaviour
{
    public GameObject miniWin;

    public void MiniGameWon()
    {
        //miniWin.SetActive(true);
        miniWin.GetComponent<AudioSource>().Play();
    }
}
