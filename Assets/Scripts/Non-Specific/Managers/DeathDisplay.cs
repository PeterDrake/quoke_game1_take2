﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Threading;

/// <summary>
/// Manager class for killing the player and displaying death screen 
/// </summary>
public class DeathDisplay : UIElement
{ 
    public GameObject toggle;
    public Text deathText;
    public float waitTime;
    public GameObject explosion;
    public AudioSource DeathMusic;
    public GameObject DMusic;
    public GameObject OtherMusic;

    private bool dead;
   
    public void Start()
    {
       //pauseOnOpen = true;
       forceOpen = true;
       locked = true;
       toggle.SetActive(false);
    }
    public void RestartLevel()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void Activate(string text)
    {
        deathText.text = text;
        DMusic.SetActive(true);
        OtherMusic.SetActive(false);
        DeathMusic.Play();
        StartCoroutine(nameof(WaitThenShow), waitTime);
    }

    private IEnumerator WaitThenShow(float time)
    {
        float theTime = time;
        while (theTime>0)
        {
            yield return new WaitForSeconds(0.1f);
            theTime--;
        }
        UIManager.Instance.SetAsActive(this);
        while (theTime<time)
        {
            yield return new WaitForSeconds(0.5f);
            theTime++;
        }
        Destroy(explosion);
    }

    public override void Open()
    {
        toggle.SetActive(true);
    }

    public override void Close()
    {
        toggle.SetActive(false);
    }
}
