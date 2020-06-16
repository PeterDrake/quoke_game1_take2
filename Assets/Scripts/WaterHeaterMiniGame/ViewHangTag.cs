using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ViewHangTag : MonoBehaviour
{
    public GameObject Hangtag;
    public Button Close;

    private bool isOpen;

    private void Start()
    {
        //Hangtag.SetActive(false);
        //isOpen = false;
    }

    public void OnMouseDown()
    {
        Debug.Log("Before isOPen is " + isOpen);
        if (!isOpen)
        {
            Hangtag.SetActive(true);
            isOpen = true;
            Debug.Log("Click to open & is open should be true" + isOpen);
        }
    }

    public void closeHangTag()
    {
        if (isOpen)
        {
            Hangtag.SetActive(false);
            isOpen = false;
        }
        Debug.Log("Close & isOpen = " + isOpen);
    }
}
