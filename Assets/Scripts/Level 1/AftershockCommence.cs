using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AftershockCommence : MonoBehaviour
{

    private bool LeftHouse;
    public AudioSource boomAudio;
    public GameObject bigBoom;



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
                //QuakeManager.Instance.TriggerQuake();
                //player dies in an explosion
                //new WaitForSeconds(3f);
                bigBoom.SetActive(true);
                //boomAudio.Play();
                Systems.Status.PlayerDeath("You died in a gas explosion");
            }
        }
    }
}
