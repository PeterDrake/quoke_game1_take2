using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class WaterHeaterMaster : MonoBehaviour
{
    public GameObject Win;
    public GameObject Wrong;

    public UnityAction OnWin;
    public UnityAction OnExit;

    public GameObject ElectricBox;
    public GameObject WaterPipe;
    public GameObject AirPipe;
    public GameObject WaterSpout;

    public bool stepOne;
    public bool stepTwo;
    public bool stepThree;
    public bool stepFour;

    private void Start()
    {
        resetSteps();
    }

    public bool CheckAnswers(string tag)
    {
        if ((tag == "ElectricBox" && !stepOne && !stepTwo && !stepThree && !stepFour )
        || (tag == "WaterPipe" && stepOne && !stepTwo && !stepThree && !stepFour)
        || (tag == "AirPipe" && stepOne && stepTwo && !stepThree && !stepFour)
        || (tag == "WaterSpout" && stepOne && stepTwo && stepThree && !stepFour))
        {
            return true;
        }
        return false;
    }

    public void resetSteps()
    {
        stepOne = false;
        stepTwo = false;
        stepThree = false;
        stepFour = false;
        ElectricBox.SetActive(false);
        WaterPipe.SetActive(false);
        AirPipe.SetActive(false);
        WaterSpout.SetActive(false);
    }

    public void Leave()
    {
        OnExit.Invoke();
    }

    public IEnumerable TryAgain()
    {
        Wrong.SetActive(true);
        yield return new WaitForSeconds(3f);
        Wrong.SetActive(false);
    }

    public void WinLeave()
    {
        OnWin.Invoke();
    }
}
