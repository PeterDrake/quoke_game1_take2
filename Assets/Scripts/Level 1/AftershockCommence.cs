using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AftershockCommence : MonoBehaviour
{

    private bool LeftHouse;


    public void LeavingHouse()
    {
        LeftHouse = true;
    }


    // Start is called before the first frame update
    void Start()
    {
        LeftHouse = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (LeftHouse)
            {
                QuakeManager.Instance.TriggerQuake();
                new WaitForSeconds(3f);
                Systems.Status.PlayerDeath("You died in the aftershock");
            }
        }
    }
}
