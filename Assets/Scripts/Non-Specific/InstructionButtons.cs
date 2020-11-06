using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class InstructionButtons : MonoBehaviour
{
    public GameObject close1;
    public GameObject close2;
    public GameObject next;
    public GameObject back;

    private Button close1btn;
    private Button close2btn;
    private Button nextbtn;
    private Button backbtn;

    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(null);
        close1btn = close1.GetComponent<Button>();
        close2btn = close2.GetComponent<Button>();
        nextbtn = next.GetComponent<Button>();
        backbtn = back.GetComponent<Button>();

        EventSystem.current.SetSelectedGameObject(next.gameObject);
        Navigation nav = close1btn.navigation;
        nav.mode = Navigation.Mode.Explicit;
        nav.selectOnDown = nextbtn;
        nav.selectOnUp = nextbtn;

        nav = nextbtn.navigation;
        nav.mode = Navigation.Mode.Explicit;
        nav.selectOnDown = close1btn;
        nav.selectOnUp = close1btn;

        nextbtn.Select();
    }

    public void PageOneNav()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(next.gameObject);
        Navigation nav = close1btn.navigation;
        nav.mode = Navigation.Mode.Explicit;
        nav.selectOnDown = nextbtn;
        nav.selectOnUp = nextbtn;

        nav = nextbtn.navigation;
        nav.mode = Navigation.Mode.Explicit;
        nav.selectOnDown = close1btn;
        nav.selectOnUp = close1btn;

        nextbtn.Select();
    }

    public void PageTwoNav()
    {
        EventSystem.current.SetSelectedGameObject(null);
        EventSystem.current.SetSelectedGameObject(close2.gameObject);
        Navigation nav = close2btn.navigation;
        nav.mode = Navigation.Mode.Explicit;
        nav.selectOnDown = backbtn;
        nav.selectOnUp = backbtn;

        nav = backbtn.navigation;
        nav.mode = Navigation.Mode.Explicit;
        nav.selectOnDown = close2btn;
        nav.selectOnUp = close2btn;

        close2btn.Select();
    }

    [System.Obsolete]
    private void Update()
    {
        if (EventSystem.current.lastSelectedGameObject != EventSystem.current.currentSelectedGameObject)
        {
            print("currently selected : " + EventSystem.current.currentSelectedGameObject);

        }
    }

}
