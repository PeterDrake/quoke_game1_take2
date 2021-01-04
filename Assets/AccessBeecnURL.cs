using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessBeecnURL : MonoBehaviour
{
    

    public void OpenURL()
    {
        Application.ExternalEval("window.open(\"http://www.unity3d.com\")");
        // Application.OpenURL("https://forms.gle/GGUAqY9o8oL985jm8");
        //Debug.Log("is this working?");
    }
    
}
