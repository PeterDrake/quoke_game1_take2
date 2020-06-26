using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShovel : MonoBehaviour
{
    private float movementSpeed = 0.5f;

    
   /* void Update()
    {
        Vector3 Target = new Vector3(transform.position.x, -1, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, Target, movementSpeed * Time.deltaTime);
        //transform.Rotate(Vector3.up* Time.deltaTime); 
    }*/
   
    public void Dig()
    {
        //float verticalInput = Input.GetAxis("Vertical");
        Debug.Log(transform.position.x);
        Debug.Log(transform.position.y);
        Debug.Log(transform.position.z);
        StartCoroutine(nameof(DigVertically));

        
        //transform.position = Vector3.MoveTowards(transform.position, Target, movementSpeed * Time.deltaTime);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 180, 0), movementSpeed * Time.deltaTime);


        //Debug.Log("transform position y is " + transform.position.y.ToString());
        //transform.position = transform.position + new Vector3(0, -1 * movementSpeed * Time.deltaTime, 0);
        //verticalInput = Input.GetAxis("Vertical");


        //transform.position = transform.position + new Vector3(0, -5*movementSpeed*Time.deltaTime, 0);
    }


    private IEnumerator DigVertically()
    {
        //Moves shovel down
        while (transform.position.y > -0.8f)
        {
            Vector3 Target = new Vector3(transform.position.x, -10, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, Target, movementSpeed * Time.deltaTime);
            yield return new WaitForSeconds(0.0005f);
        }

        //Moves shovel to the side
        while (transform.position.x > 71.81f && transform.position.y<1)
        {
            Vector3 Target = new Vector3(71, 0.5f, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, Target, movementSpeed * Time.deltaTime);
            yield return new WaitForSeconds(0.0005f);
        }
            
        //Moves shovel to the start position
        
        transform.position = new Vector3(73.04f, 0.14f * movementSpeed * Time.deltaTime, transform.position.z);
        
    }
}
