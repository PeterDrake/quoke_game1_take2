using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableController : MonoBehaviour
{
    public GameObject Controller;
    public GameObject CompostingPlace;

    void Start()
    {
        //nothing, but this method has to be here because of sheltervisit
    }
    
    // Update is called once per frame
    private void Check()
    {
        if (CompostingPlace.activeSelf)
        {
            Controller.SetActive(true);
        }
    }
}
