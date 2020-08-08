using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuakeCommence : MonoBehaviour
{

    private bool ExploreBath;
    private bool ExploreKitc;
    
    private bool _satisfied;


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
        Systems.Objectives.Register("EXPLOREAREA", () => _satisfied = true);
        Systems.Objectives.printObjectives();
        Debug.Log("Start called");
        ExploreBath = false;
        ExploreKitc = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (ExploreBath && ExploreKitc)
            {
                Systems.Objectives.Satisfy("EXPLOREAREA");
                QuakeManager.Instance.TriggerQuake();
            }
        }
    }
}
