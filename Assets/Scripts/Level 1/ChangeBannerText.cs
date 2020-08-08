using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeBannerText : MonoBehaviour
{
    public InformationCanvas _canvas;
    public string words;

    public void Change()
    {
        _canvas. ChangeText(words);
    }
}
