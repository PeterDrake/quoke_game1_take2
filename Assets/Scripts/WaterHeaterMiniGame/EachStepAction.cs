using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EachStepAction : MonoBehaviour
{
    public GameObject check;
    public GameObject current;
    public GameObject MovingPart;

    public GameObject PIP;

    public WaterHeaterMaster Master;

    private KnobRotating move;

    private void Awake()
    {
        check.SetActive(false);
        PIP.SetActive(false);
        move = MovingPart.GetComponent<KnobRotating>();
        move.enabled = false;
    }

    public void OnMouseDown()
    {
        if (Master.CheckAnswers(current.tag) == 1)
        {
            if (current.tag == "ElectricBox")
            {
                move.enabled = true;
                Master.stepOne = true;
            }
            else if (current.tag == "WaterPipe")
            {
                move.enabled = true;
                Master.stepTwo = true;
            }
            else if (current.tag == "AirPipe")
            {
                move.enabled = true;
                Master.stepThree = true;
            }
            else if (current.tag == "WaterSpout")
            {
                move.enabled = true;
                Master.stepFour = true;
            }
            Debug.Log("CHECKED OFF " + current.tag);
            check.SetActive(true);
            PIP.SetActive(true);
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
