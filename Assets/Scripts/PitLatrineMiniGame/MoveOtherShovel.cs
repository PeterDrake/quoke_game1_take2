using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveOtherShovel : MonoBehaviour
{
    private float movementSpeed = 0.5f;

    public GameObject Pit1;
    public GameObject Pit2;
    public GameObject Pit3;
    public GameObject Dirt1;
    public GameObject Dirt2;
    public GameObject Dirt3;
    public GameObject Dirt4;
    public GameObject Dirt5;    //Dirt on the shovel
    public ParticleSystem DirtFlies;

    private void Start()
    {
        DirtFlies.Stop();
        //Stop all coroutines
    }

    public void Dig()
    {
        StartCoroutine(nameof(DigVertically));
    }
    
    private IEnumerator DigVertically()
    {
        //Moves shovel down
        while (transform.position.y > 1f)
        {
            Vector3 Target = new Vector3(transform.position.x, -5, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, Target, movementSpeed * Time.deltaTime);
            yield return new WaitForSeconds(0.0005f);
            if (transform.position.y < 1.07)
            {
                DirtFlies.Play();
            }
        }
        
        yield return new WaitForSeconds(0.5f);
        
        MakePitAppear();
        
        Dirt5.SetActive(true); //Dirt on the shovel

        //Moves shovel to the side
        while (transform.position.x > 77 && transform.position.y<1.41)
        {
            Vector3 Target = new Vector3(77, 1.4f, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, Target, movementSpeed * Time.deltaTime);
            yield return new WaitForSeconds(0.0005f);
        }

        Dirt5.SetActive(false);
        MakeDirtAppear();
        DirtFlies.Stop();
        
        //Moves shovel to the start position
        transform.position = new Vector3(78.34f, 1.42f, transform.position.z);
        
    }

    private void MakePitAppear()
    {
        if (Pit3.activeSelf)
        {
            Pit2.SetActive(false);
            //disable buttons while pit 3 gets smaller and smaller
            //display message canvas
        }
        
        else if (Pit2.activeSelf)
        {
            Pit3.SetActive(true);
        }
        
        else if (Pit1.activeSelf)
        {
            Pit2.SetActive(true);
        }
        else
        {
            Pit1.SetActive(true);
        }
    }

    private void MakeDirtAppear()
    {
        if (Dirt3.activeSelf)
        {
            Dirt4.SetActive(true);
        }
        
        else if (Dirt2.activeSelf)
        {
            Dirt3.SetActive(true);
        }
        
        else if (Dirt1.activeSelf)
        {
            Dirt2.SetActive(true);
        }
        else
        {
            Dirt1.SetActive(true);
        }
    }

}
