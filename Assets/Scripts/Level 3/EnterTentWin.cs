using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterTentWin : MonoBehaviour
{
    private const string EventKey = "LEVELFINISHED";
    private const string SATISFIED = "Press 'E' to rest in Ahmad's van";
    private const string NOT_SATISFIED = "";
    public UIElement winCanvas;
    private InteractWithObject _interact;
    private bool _satisfied;

    private void Start()
    {
        _interact = GetComponent<InteractWithObject>();
        Systems.Objectives.Register(EventKey, () => _satisfied = true);
    }


    public void OnEnter()
    {
        _interact.SetInteractText(_satisfied ? SATISFIED : NOT_SATISFIED);
        //_interact.BlinkWhenPlayerNear = _satisfied;
        if (_satisfied)
        {
            UIManager.Instance.SetAsActive(winCanvas); //changed from winCanvas

        }
    }

}
