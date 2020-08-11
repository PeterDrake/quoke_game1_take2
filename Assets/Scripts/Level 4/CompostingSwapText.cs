using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompostingSwapText : MonoBehaviour
{
    private InteractWithObject _interact;
    private void Start()
    {
        _interact = GetComponent<InteractWithObject>();
    }

    public void SwapTextBox()
    {
        _interact.SetInteractText("Press 'E' to build a box");
    }

    public void SwapTextCarbon()
    {
        _interact.SetInteractText("Press 'E' to add carbon material to box");
    }
    
}
