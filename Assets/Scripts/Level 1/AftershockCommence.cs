using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AftershockCommence : MonoBehaviour
{

    private bool LeftHouse;


    public void LeavingHouse()
    {
        Debug.Log("Left House");

        LeftHouse = true;

    }


    // Start is called before the first frame update
    void Start()
    {
        LeftHouse = false;
    }

    // This is reentry to the house
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (LeftHouse)
            {
                Debug.Log("Aftershock");
                //QuakeManager.Instance.TriggerQuake();
                QuakeManager.Instance.TriggerCountdown(5f);
                new WaitForSeconds(5f);
                Debug.Log("You died in the aftershock");
                Systems.Status.PlayerDeath("You died in the aftershock");
                
            }
        }
    }
}
