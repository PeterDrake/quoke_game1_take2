using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EachStepAction : MonoBehaviour
{
    public GameObject check;
    public GameObject current;

    public WaterHeaterMaster Master;

    private void Awake()
    {
        check.SetActive(false);
    }

    public void OnMouseDown()
    {
        if (Master.CheckAnswers(current.tag) == 1)
        {
            if (current.tag == "ElectricBox")
            {
                Master.stepOne = true;
            }
            else if (current.tag == "WaterPipe")
            {
                Master.stepTwo = true;
            }
            else if (current.tag == "AirPipe")
            {
                Master.stepThree = true;
            }
            else if (current.tag == "WaterSpout")
            {
                Master.stepFour = true;
            }
            Debug.Log("CHECKED OFF " + current.tag);
            check.SetActive(true);
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
