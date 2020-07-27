﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlatFollow : MonoBehaviour
{
    public GameObject following;
    [Header("Height of camera: 13.5, Height of Chars: 1.7")]
    public float height;
    public bool mobile;

    private Transform location;


    // Start is called before the first frame update
    void Start()
    {
        location = GetComponent<Transform>();
        location.transform.position = new Vector3
            (following.transform.position.x, height, following.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (mobile)
        {
            StartCoroutine(follow());
        }
    }

    private IEnumerator follow()
    {
        while (true)
        {
            location.transform.position = new Vector3
                (following.transform.position.x, height, following.transform.position.z);
            yield return new WaitForSeconds(0.01f);
        }
    }
}
