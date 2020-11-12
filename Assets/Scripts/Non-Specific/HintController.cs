using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HintController : MonoBehaviour
{
    public GameObject interactables;
    public Text hintText;
    

    // Start is called before the first frame update
    void Start()
    {
        print("HINTS ARE " + SavedData.hints);
        if (SavedData.hints)
        {
            interactables.SetActive(true);
            hintText.text = "Hints ON";
        }
        else
        {
            interactables.SetActive(false);
            hintText.text = "Hints OFF";
        }
    }

    public void TurnHintsOn()
    {
        hintText.text = "Hints ON";
        SavedData.hints = true;
        print("HINTS ARE " + SavedData.hints);

    }

}
