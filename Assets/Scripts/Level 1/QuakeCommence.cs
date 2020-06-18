using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuakeCommence : MonoBehaviour
{

    private bool ExploreBath;
    private bool ExploreKitc;


    public void ExploredBath()
    {
        ExploreBath = true;
    }

    public void ExploredKitc()
    {
        ExploreKitc = true;
    }

    
    // Start is called before the first frame update
    void Start()
    {
        ExploreBath = false;
        ExploreKitc = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (ExploreBath && ExploreKitc)
            {
                QuakeManager.Instance.TriggerQuake();
            }
        }
    }
}
