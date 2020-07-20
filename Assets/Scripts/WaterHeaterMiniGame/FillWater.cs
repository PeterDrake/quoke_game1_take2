using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;


public class FillWater : MonoBehaviour
{
    public WaterHeaterMaster Master;
    public Image water;

    public void pourWater()
    {
        water.fillAmount += .2f;
        if (water.fillAmount >= 1f)
        {
            Master.StopAllCoroutines();
            Master.Win.SetActive(true);

            GameObject.Find("ImportantObjects").GetComponent<MiniWin>().MiniGameWon();

            /*
            print("Important = " + GameObject.Find("ImportantObjects"));                                                        //Finds the ImportantObjects GameObject
            //print("Important Heater = " + GameObject.Find("ImportantObjects").Find("WaterHeaterBody"));
            print("Important + HeaterChild = " + GameObject.Find("ImportantObjects").transform.FindChild("WaterHeaterBody"));   //null
            print("Important + Heater = " + GameObject.Find("ImportantObjects").transform.Find("WaterHeaterBody"));             //null
            print("WaterHeater = " + GameObject.Find("WaterHeaterBody"));                                                       //null
            //print("Component = " + GameObject.Find("WaterHeaterBody").GetComponent<WaterHeaterVisit>());
            print("The waterheater = " + GameObject.Find("ImportantObjects/WaterHeaterBody"));                                  //null
            //print("that waterheater = " + GameObject.Find("ImportantObject\ WaterHeaterBody"));
            GameObject.Find("WaterHeaterBody").GetComponent<WaterHeaterVisit>().MiniGameWon();
            */
        }
    }

}
