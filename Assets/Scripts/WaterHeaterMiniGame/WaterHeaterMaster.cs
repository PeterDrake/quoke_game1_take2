using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WaterHeaterMaster : MonoBehaviour
{
    public GameObject Win;
    public GameObject Wrong;

    public UnityAction OnWin;
    public UnityAction OnExit;

    public GameObject ElectricBoxCheck;
    public GameObject WaterPipeCheck;
    public GameObject AirPipeCheck;
    public GameObject WaterSpoutCheck;

    public bool stepOne;
    public bool stepTwo;
    public bool stepThree;
    public bool stepFour;

    public Button FillButton;
    public GameObject Fill;

    private GameObject ElectricBox;
    private GameObject WaterPipe;
    private GameObject AirPipe;
    private GameObject WaterSpout;

    private void Start()
    {
        stepOne = false;
        stepTwo = false;
        stepThree = false;
        stepFour = false;
        ElectricBoxCheck.SetActive(false);
        WaterPipeCheck.SetActive(false);
        AirPipeCheck.SetActive(false);
        WaterSpoutCheck.SetActive(false);
        Fill.SetActive(false);

        ElectricBox = GameObject.FindGameObjectWithTag("ElectricBox");
        WaterPipe = GameObject.FindGameObjectWithTag("WaterPipe");
        AirPipe = GameObject.FindGameObjectWithTag("AirPipe");
        WaterSpout = GameObject.FindGameObjectWithTag("WaterSpout");
    }


    public int CheckAnswers(string tag)
    {
        //next step to add check
        if ((tag == "ElectricBox" && !stepOne && !stepTwo && !stepThree && !stepFour )
        || (tag == "WaterPipe" && stepOne && !stepTwo && !stepThree && !stepFour)
        || (tag == "AirPipe" && stepOne && stepTwo && !stepThree && !stepFour)
        || (tag == "WaterSpout" && stepOne && stepTwo && stepThree && !stepFour))
        {
            return 1;
        }
        //same step thats already check
        else if ((tag == "ElectricBox" && stepOne)
        || (tag == "WaterPipe" && stepOne && stepTwo)
        || (tag == "AirPipe" && stepOne && stepTwo && stepThree)
        || (tag == "WaterSpout" && stepOne && stepTwo && stepThree && stepFour))
        {
            return 0;
        }
        else
        {
            return -1;

        }
    }

    public void isDone()
    {
        if(stepOne && stepTwo && stepThree && stepFour)
        {
            //Destroy(ElectricBox.GetComponent<MouseInteract>());
            //Destroy(WaterPipe.GetComponent<MouseInteract>());
            //Destroy(AirPipe.GetComponent<MouseInteract>());
            //Destroy(WaterSpout.GetComponent<MouseInteract>());
            Destroy(ElectricBox.GetComponent<EachStepAction>());
            Destroy(WaterPipe.GetComponent<EachStepAction>());
            Destroy(AirPipe.GetComponent<EachStepAction>());
            Destroy(WaterSpout.GetComponent<EachStepAction>());

            Fill.SetActive(true);
            StartCoroutine(BlinkText());
        }
    }

    public void resetSteps()
    {
        StartCoroutine(TryAgain());
        Debug.Log("reset");
        stepOne = false;
        stepTwo = false;
        stepThree = false; 
        stepFour = false;
        ElectricBoxCheck.SetActive(false);
        WaterPipeCheck.SetActive(false);
        AirPipeCheck.SetActive(false);
        WaterSpoutCheck.SetActive(false);
    }

    public void Leave()
    {
        OnExit.Invoke();
    }

    public void WinLeave()
    {
        OnWin.Invoke();
    }

    public IEnumerator TryAgain()
    {
        Debug.Log("try again message");
        Wrong.SetActive(true);
        yield return new WaitForSeconds(2f);
        Wrong.SetActive(false);
    }

    public IEnumerator BlinkText()
    {
        while (true)
        {
            FillButton.GetComponent<UnityEngine.UI.Image>().color = Color.blue;
            yield return new WaitForSeconds(.5f);
            FillButton.GetComponent<UnityEngine.UI.Image>().color = Color.white;
            yield return new WaitForSeconds(.5f);
        }
    }

}
