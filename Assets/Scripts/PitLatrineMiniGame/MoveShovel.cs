using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShovel : MonoBehaviour
{
    private float movementSpeed = 0.5f;

    public GameObject Pit1;
    public GameObject Pit2;
    public GameObject Dirt1;
    public GameObject Dirt2;
    public GameObject Dirt3;    //Dirt on the shovel
    public GameObject Water;
    public ParticleSystem DirtFlies;

    private void Start()
    {
        DirtFlies.Stop();
    }

    public void Dig()
    {
        StartCoroutine(nameof(DigVertically));
        StartCoroutine(nameof(FillWaterPond));
    }
    
    private IEnumerator DigVertically()
    {
        //Moves shovel down
        while (transform.position.y > -0.8f)
        {
            Vector3 Target = new Vector3(transform.position.x, -10, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, Target, movementSpeed * Time.deltaTime);
            yield return new WaitForSeconds(0.0005f);
            if (transform.position.y < -0.4)
            {
                DirtFlies.Play();
            }
        }

        
        
        yield return new WaitForSeconds(0.5f);
        
        MakePitAppear();
        
        Dirt3.SetActive(true); //Dirt on the shovel

        //Moves shovel to the side
        while (transform.position.x > 71.81f && transform.position.y<1)
        {
            Vector3 Target = new Vector3(71, 0.5f, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, Target, movementSpeed * Time.deltaTime);
            yield return new WaitForSeconds(0.0005f);
        }

        Dirt3.SetActive(false);
        MakeDirtAppear();
        DirtFlies.Stop();
        if (Dirt2.activeSelf == true)
        {
            Water.SetActive(true);
        }
        //Moves shovel to the start position
        transform.position = new Vector3(73.04f, 0.14f * movementSpeed * Time.deltaTime, transform.position.z);
        
    }

    private void MakePitAppear()
    {
        if (Pit1.activeSelf == true)
        {
            Pit2.SetActive(true);
            //Water.SetActive(true);
        }
        else
        {
            Pit1.SetActive(true);
        }
    }

    private void MakeDirtAppear()
    {
        if (Dirt1.activeSelf == true)
        {
            Dirt2.SetActive(true);
        }
        else
        {
            Dirt1.SetActive(true);
        }
    }

    private IEnumerator FillWaterPond()
    {
        yield return new WaitForSeconds(1f);
    }
    
}
