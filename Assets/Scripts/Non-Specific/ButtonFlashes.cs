using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonFlashes : MonoBehaviour
{
    public Button.ButtonClickedEvent onClick;
    public Button theButton;
    
   
    private void Start()
    {
        StartCoroutine(BlinkText());
    }

    public IEnumerator BlinkText()
    {
        while (true)
        {
            theButton.GetComponent<Image>().color = Color.red;
            yield return new WaitForSeconds(0.3f);
            theButton.GetComponent<Image>().color = Color.white;
            //theButton.colors = Color.white;
            yield return new WaitForSeconds(0.15f);
        }
    }
}
