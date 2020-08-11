using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompostingSwapText : MonoBehaviour
{
    public InteractWithObject _interact;

    public void SwapTextBox()
    {
        _interact.SetInteractText("Press 'E' to build a box");
    }

    public void SwapTextCarbon()
    {
        _interact.SetInteractText("Press 'E' to add carbon material to box");

    }
    
}
