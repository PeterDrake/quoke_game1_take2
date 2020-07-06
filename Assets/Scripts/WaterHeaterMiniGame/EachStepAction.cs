using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EachStepAction : MonoBehaviour
{
    public GameObject check;
    public GameObject current;

    public GameObject PIP;

    public WaterHeaterMaster Master;

    private KnobRotating move;

    public GameObject rawimage;


    private void Awake()
    {
        check.SetActive(false);
        PIP.SetActive(false);
        rawimage.SetActive(false);
    }

    public void OnMouseDown()
    {
        if (Master.CheckAnswers(current.tag) == 1)
        {
            if (current.tag == "ElectricBox")
            {
                GameObject.Find("Flip").AddComponent<KnobRotating>();
                Master.stepOne = true;

            }
            else if (current.tag == "WaterPipe")
            {
                GameObject.Find("Turn").AddComponent<KnobRotating>();
                Master.stepTwo = true;

            }
            else if (current.tag == "AirPipe")
            {
                GameObject.Find("Lever").AddComponent<KnobRotating>();
                Master.stepThree = true;

            }
            else if (current.tag == "WaterSpout")
            {
                GameObject.Find("Water").AddComponent<KnobRotating>();
                Master.stepFour = true;

            }
            Debug.Log("CHECKED OFF " + current.tag);
            check.SetActive(true);
            PIP.SetActive(true);
            rawimage.SetActive(true);
            check.GetComponent<Image>().color = Color.green;
            Master.isDone();

        }
        if (Master.CheckAnswers(current.tag) == -1)
        {
            //Master.TryAgain();
           
            Master.resetSteps();
            Debug.Log("Wrong Step");
            
        }

        if (Master.CheckAnswers(current.tag) == 0)
        {
            Debug.Log("Already Clicked");
        }
       
    }
}
