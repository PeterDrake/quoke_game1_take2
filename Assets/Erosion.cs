using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Erosion : MonoBehaviour
{
    private Vector3 scaleChange;
    
    // Start is called before the first frame update
    void Start()
    {
        scaleChange = new Vector3(-0.001f, 0, -0.0001f);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale.x > 0.1f)
        {
            transform.localScale += scaleChange;
        }

        else
        {
            this.gameObject.SetActive(false);
        }
    }

}