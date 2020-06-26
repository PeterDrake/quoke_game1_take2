using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveShovel : MonoBehaviour
{
    private float movementSpeed = 0.5f;

    
    void Update()
    {
        Vector3 Target = new Vector3(transform.position.x, -1, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, Target, movementSpeed * Time.deltaTime);
        //transform.Rotate(Vector3.up* Time.deltaTime); 
    }
    
    public void Dig()
    {
        //float verticalInput = Input.GetAxis("Vertical");
        Debug.Log(transform.position.y);
        Debug.Log(transform.rotation.y);
        
       // StartCoroutine(nameof(DigVertically));
        //transform.position = Vector3.MoveTowards(transform.position, Target, movementSpeed * Time.deltaTime);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 180, 0), movementSpeed * Time.deltaTime);


        //Debug.Log("transform position y is " + transform.position.y.ToString());
        //transform.position = transform.position + new Vector3(0, -1 * movementSpeed * Time.deltaTime, 0);
        //verticalInput = Input.GetAxis("Vertical");


        //transform.position = transform.position + new Vector3(0, -5*movementSpeed*Time.deltaTime, 0);
    }


    private void DigVertically()
    {
        
        Vector3 Target = new Vector3(transform.position.x, -10, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, Target, movementSpeed * Time.deltaTime);
    }
}
