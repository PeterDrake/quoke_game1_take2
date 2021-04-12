using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VideoIntro : MonoBehaviour
{
    public GameObject videoDisplayer;
    public GameObject intro;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(nameof(ShowIntro));
        
    }

    private IEnumerator ShowIntro(){
        print("show");
        yield return new WaitForSeconds(2f);
        print("hide");
        intro.SetActive(false);
        videoDisplayer.SetActive(true);
        GetComponent<PlayVideo>().play = true; 
    }
}
