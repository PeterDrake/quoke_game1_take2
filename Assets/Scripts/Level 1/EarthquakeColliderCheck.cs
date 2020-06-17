using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EarthquakeColliderCheck : MonoBehaviour
{
    public UnityEvent OnEnter;

    public UnityEvent OnExit;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Logger.Instance.Log("Player entered area of: "+name);
            OnEnter.Invoke();
        }
    }

    public void OnTriggerExit(Collider other)    //Destroy earthquake script and only leave aftershock???
    {
        if (other.CompareTag("Player"))
        {
            Logger.Instance.Log("Player exited area of: "+name);
            OnExit.Invoke();
        }

    }
}
