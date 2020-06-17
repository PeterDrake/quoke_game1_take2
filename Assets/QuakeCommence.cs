using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuakeCommence : MonoBehaviour
{

    private int Explored;

    public void incrementExplored()
    {
        Explored = Explored + 1;
    }
    
    // Start is called before the first frame update
    void Start()
    {
        Explored = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Explored >= 2)
            {
                QuakeManager.Instance.TriggerQuake();
            }
        }
    }
}
