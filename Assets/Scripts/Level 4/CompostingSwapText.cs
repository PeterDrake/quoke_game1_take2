using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompostingSwapText : MonoBehaviour
{
    public InteractWithObject _interact;
    public bool made; 

    public void SwapTextBox()
    {
        _interact.SetInteractText("Press 'E' to build a box");
    }

    public void SwapTextCarbon()
    {
        if (!made)
        {
            _interact.SetInteractText("Press 'E' to add carbon material to box");
        }
        else
        {
            _interact.SetInteractText("Press 'E' to use composting toilet");
        }
    }
    
}
