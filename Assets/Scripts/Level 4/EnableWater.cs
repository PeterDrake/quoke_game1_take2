﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableWater : MonoBehaviour
{
    public GameObject Water;
    public GameObject Water1;
    public InformationCanvas _canvas;
    public string words;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(nameof(EnableTheWater));
    }
    
    private IEnumerator EnableTheWater()
    {
        yield return new WaitForSeconds(7f);
        Water1.SetActive(false);
        Water.SetActive(true);
        _canvas.ChangeText(words);
    }
}