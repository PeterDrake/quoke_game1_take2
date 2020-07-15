using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuScreenDisplayer : UIElement
{
    private GameObject toggler;
    // Start is called before the first frame update
    void Start()
    {
        toggler = GameObject.Find("EscapeClosed");
        UIManager.Instance.Initialize(this);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void Open()
    {
        toggler.SetActive(true);
    }

    public override void Close()
    {
        toggler.SetActive(false);
    }
}
