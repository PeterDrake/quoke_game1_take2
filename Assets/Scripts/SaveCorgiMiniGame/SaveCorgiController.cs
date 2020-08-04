using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveCorgiController : MonoBehaviour
{
    private DragTarp script;

    public GameObject Tarp;
    public GameObject Corgi;

    void Start()
    {
        script = Tarp.GetComponent<DragTarp>();
    }

    void Update()
    {
        if (Tarp.transform.position.x < -116f)
        {
            Destroy(script);
            StartCoroutine(nameof(CorgiSit));
            //won
        }
    }

    private IEnumerator CorgiSit()
    {
        yield return new WaitForSeconds(1f);
        Corgi.GetComponent<Animator>().enabled = true;
    }
    
    //First, instructions appear
    // Then, you move tarp for corgi to jump
    // animation corgi doesn't want to jump
    // hot dog Frank comes there
    // corgi jumps
    // win screen2
}
