using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameButton : UIElement
{
    private GameObject toggler;
    // Start is called before the first frame update
    void Start()
    {
        toggler = GameObject.Find("Button");
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
