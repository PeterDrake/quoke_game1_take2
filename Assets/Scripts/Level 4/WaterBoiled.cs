using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBoiled : MonoBehaviour
{

    //public InformationCanvas _canvas;
    //public string words;
    //public string words1;

    public GameObject Pot;
    public GameObject Steam;
    public GameObject Fire;
    public GameObject Fire2;
    
    void Update()
    {


       // _canvas.ChangeText(words1);
        //_canvas.ChangeText(words);

        if (Pot.activeSelf)
        {
            StartCoroutine(nameof(DestroyFire));
           // _canvas.ChangeText(words1);
        }
    }
    
    private IEnumerator DestroyFire()
    {
        yield return new WaitForSeconds(3f);
        Steam.SetActive(true);
        Fire.SetActive(false);
        yield return new WaitForSeconds(2f);
        Fire2.SetActive(false);
        yield return new WaitForSeconds(3f);
        Steam.SetActive(false);
        this.gameObject.SetActive(false);
        
    }
    
}
