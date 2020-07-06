using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlIndoorsAreaCheck : MonoBehaviour
{
    public GameObject InsideCheck;
    public GameObject DeathScreen;
    
    // Start is called before the first frame update
    void Start()
    {
        InsideCheck.SetActive(false);
        StartCoroutine(nameof(Wait));
    }

    void Update()
    {
        if (DeathScreen.activeSelf)
        {
            InsideCheck.SetActive(false);
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(10f);
        InsideCheck.SetActive(true);
    }
    
}