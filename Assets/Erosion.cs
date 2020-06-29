using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Erosion : MonoBehaviour
{
    private Vector3 scaleChange;
    private bool check;
    public GameObject Pit2;
    public GameObject Pit3;
    public GameObject Shovel;

    // Start is called before the first frame update
    void Start()
    {
        scaleChange = new Vector3(-0.001f, 0, -0.0001f);
    }

    // Update is called once per frame
    void Update()
    {
        Pit2.SetActive(false);

        if (Shovel.transform.position.x == 78.34f)
        {
            if (transform.localScale.x > 0.1f)
            {
                transform.localScale += scaleChange;
            }
            
            else
            {
                check = false;
                Pit3.SetActive(false);
            }
        }
        
        
    }

}