using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlinkFrame : MonoBehaviour
{
    public GameObject frame1;
    public GameObject frame2;
    public GameObject frame3;
    public GameObject frame4;

    private float timer;
    private bool blinkOn;

    private void Start()
    {
        frame1.GetComponent<MeshRenderer>().material = (Material)Resources.Load("Materials/Ground");
        frame2.GetComponent<MeshRenderer>().material = (Material)Resources.Load("Materials/Ground");
        frame3.GetComponent<MeshRenderer>().material = (Material)Resources.Load("Materials/Ground");
        frame4.GetComponent<MeshRenderer>().material = (Material)Resources.Load("Materials/Ground");
    }

    public void Blink()
    {
        print("BLINKKKINHG");
        StartCoroutine("BlinkF");
       
    }

    private IEnumerator BlinkF()
    {
        for(int i = 1; i > 0; i ++)
        { 
            if (blinkOn)
            { 
                frame1.GetComponent<MeshRenderer>().material = (Material)Resources.Load("Materials/Mirror");
                frame2.GetComponent<MeshRenderer>().material = (Material)Resources.Load("Materials/Mirror");
                frame3.GetComponent<MeshRenderer>().material = (Material)Resources.Load("Materials/Mirror");
                frame4.GetComponent<MeshRenderer>().material = (Material)Resources.Load("Materials/Mirror");
                blinkOn = false;
            }
            else
            {
                frame1.GetComponent<MeshRenderer>().material = (Material)Resources.Load("Materials/Ground");
                frame2.GetComponent<MeshRenderer>().material = (Material)Resources.Load("Materials/Ground");
                frame3.GetComponent<MeshRenderer>().material = (Material)Resources.Load("Materials/Ground");
                frame4.GetComponent<MeshRenderer>().material = (Material)Resources.Load("Materials/Ground");
                blinkOn = true;
            }
            yield return new WaitForSeconds(.3f);
        }
    }

    public void StopBlink()
    {
        print("stooppppp blinkkking");
        StopCoroutine("BlinkF");
        frame1.GetComponent<MeshRenderer>().material = (Material)Resources.Load("Materials/Ground");
        frame2.GetComponent<MeshRenderer>().material = (Material)Resources.Load("Materials/Ground");
        frame3.GetComponent<MeshRenderer>().material = (Material)Resources.Load("Materials/Ground");
        frame4.GetComponent<MeshRenderer>().material = (Material)Resources.Load("Materials/Ground");
    }
}
