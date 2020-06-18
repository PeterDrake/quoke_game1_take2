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
        }
    }

}
