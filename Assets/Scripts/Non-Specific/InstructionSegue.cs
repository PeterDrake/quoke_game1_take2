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
    public GameObject close;


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
        Navigation nav = close.GetComponent<Button>().navigation;
        nav.mode = Navigation.Mode.Explicit;
        nav.selectOnUp = back.GetComponent<Button>();
        nav.selectOnLeft = back.GetComponent<Button>();
        nav.selectOnRight = null;
        close.GetComponent<Button>().navigation = nav;


    }

    public void BackPressed()
    {
        page2.SetActive(false);
        page1.SetActive(true);
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(next.gameObject);
        Navigation nav = close.GetComponent<Button>().navigation;
        nav.mode = Navigation.Mode.Explicit;
        nav.selectOnUp = next.GetComponent<Button>();
        nav.selectOnRight = back.GetComponent<Button>();
        nav.selectOnLeft = null;
        close.GetComponent<Button>().navigation = nav;
    }


}
