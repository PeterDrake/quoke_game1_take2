using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaveHouseText : MonoBehaviour
{
    public InformationCanvas _canvas;

    public void Interaction()
    {
        _canvas.ChangeText("Explore the neighborhood");
    }
}
