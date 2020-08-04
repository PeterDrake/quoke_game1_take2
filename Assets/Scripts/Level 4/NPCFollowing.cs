using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCFollowing : MonoBehaviour
{
    public GameObject Leader;
    private NavMeshAgent nav;

    // Start is called before the first frame update
    void Start()
    {
        nav = GetComponent<NavMeshAgent>();
        HeadForDestination();
    }

    private void Update()
    {
        HeadForDestination();
    }

    private void HeadForDestination()
    {
        Vector3 destination = Leader.transform.position;
        nav.SetDestination(destination);
    }
}
