using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessNETURL : MonoBehaviour
{
    public void OpenURL()
    {
        Application.OpenURL("https://forms.gle/zFXfUoMDtiKK5Gco7");
        //Debug.Log("is this working?");
    }
}
