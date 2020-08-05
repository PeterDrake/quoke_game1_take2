using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveCorgiController : MonoBehaviour
{
    private DragTarp script;

    public GameObject Tarp;
    public GameObject Corgi;
    public GameObject Banner;
    public GameObject VideoBackground;
    public GameObject VideoDisplayer;

    void Start()
    {
        script = Tarp.GetComponent<DragTarp>();
    }

    void Update()
    {
        if (Tarp.transform.position.x < -116f)
        {
            Destroy(script);
            Banner.SetActive(false);
            StartCoroutine(nameof(CorgiSit));
        }
    }

    private IEnumerator CorgiSit()
    {
        yield return new WaitForSeconds(1f);
        Corgi.GetComponent<Animator>().enabled = true;
        //yield return new WaitForSeconds(1f);
        StartCoroutine(nameof(PlayVideo));
    }

    private IEnumerator PlayVideo()
    {
        yield return new WaitForSeconds(1f);
        VideoBackground.SetActive(true);
        VideoDisplayer.SetActive(true);
    }
}
