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
        //Debug.Log("Begin : is open = " + isOpen);
    }

    public void OnMouseDown()
    {
            //isOpen = true;
            Hangtag.SetActive(true);
            //Debug.Log("is open should be true = " + isOpen);

    }

    public void closeHangTag()
    {
            //isOpen = false;
            Hangtag.SetActive(false);
            //Debug.Log("isOpen is now false = " + isOpen);
    }
}
