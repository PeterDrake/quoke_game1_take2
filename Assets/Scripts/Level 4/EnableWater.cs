﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableWater : MonoBehaviour
{
    public GameObject Water;
    public GameObject Water1;
    //public GameObject Pot;
    public InformationCanvas _canvas;
    public string words;
    public GameObject Bruce;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(nameof(EnableTheWater));
    }
    
    private IEnumerator EnableTheWater()
    {
        yield return new WaitForSeconds(7f);
        Water1.SetActive(false);
        //Pot.SetActive(false);
        Water.SetActive(true);

        Systems.Objectives.Satisfy("PotWithWater");

        _canvas.ChangeText(words);

        if (GameObject.Find("MariaAlert") != null)
        { GameObject.Find("MariaAlert").GetComponent<FlatFollow>().appear(); }
        Bruce.transform.position = new Vector3(-205, 0, -175);
        if (GameObject.Find("BrucePointer") != null)
        { GameObject.Find("BrucePointer").GetComponent<FlatFollow>().appear(); }
    }
}
