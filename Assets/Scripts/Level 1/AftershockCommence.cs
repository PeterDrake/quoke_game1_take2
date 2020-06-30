using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AftershockCommence : MonoBehaviour
{

    private bool LeftHouse;
    public AudioSource boomAudio;
    public GameObject bigBoom;
    public GameObject animateBoom;


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
                animateBoom.SetActive(true);
                new WaitForSeconds(1f);
                //boomAudio.Play();
                Systems.Status.PlayerDeath("You died in a gas explosion");
            }
        }
    }
}
