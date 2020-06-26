﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TsuBark : MonoBehaviour
{
    private const string EventKey = "LEVELFINISHED";
    private const string SATISFIED = "";
    private const string NOT_SATISFIED = "";
    public GameObject theBark;

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
        _interact.BlinkWhenPlayerNear = _satisfied;
    }
    public void Interact()
    {
        if (_satisfied)
            theBark.SetActive(true); //changed from winCanvas
    }
}