using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnobRotating : MonoBehaviour
{

    private float air = 0;
    private float pipe = 0;
    private float spout = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (gameObject.tag == "WaterPipe" && pipe < 500)
        {
            transform.Rotate(0, 0, -5f);
            pipe += 5;
        }

        if (gameObject.tag == "WaterSpout" && spout < 500)
        {
            transform.Rotate(0, 0, 5);
            spout += 5;
        }
        if (gameObject.tag == "AirPipe" && air < 90)
        {
            transform.Rotate(0, 0, -5);
            air += 5;
        }
    }
}
