using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InstructionSegue : MonoBehaviour
{
    public GameObject page1;
    public GameObject page2;
    public GameObject next;
    public GameObject back;


    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(next.gameObject);
    }

    public void NextPressed()
    {
        page1.SetActive(false);
        page2.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(back.gameObject);
    }

    public void BackPressed()
    {
        page2.SetActive(false);
        page1.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(next.gameObject);
    }


}
