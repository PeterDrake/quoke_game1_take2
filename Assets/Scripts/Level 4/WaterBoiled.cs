using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBoiled : MonoBehaviour
{
    public GameObject Barrel;
    public GameObject Steam;
    public GameObject Fire;
    public GameObject Fire2;
    
    void Update()
    {
        if (Barrel.activeSelf)
        {
            StartCoroutine(nameof(DestroyFire));
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
    }
    
}
