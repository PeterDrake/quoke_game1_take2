using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionLogger : MonoBehaviour
{
    private Collider collider;

    void Start()
    {
        collider = gameObject.GetComponent<Collider>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log(gameObject.name + " collided with " + collision.gameObject.name);
    }
}
