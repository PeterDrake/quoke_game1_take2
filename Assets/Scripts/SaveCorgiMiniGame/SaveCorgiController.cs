using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SaveCorgiController : MonoBehaviour
{
    private DragTarp script;

    public GameObject camera;
    public GameObject Frank;
    public GameObject Tarp;
    public GameObject Corgi;
    public GameObject Banner;
    public GameObject Win;

    private bool winScreen;
    private bool gameOver;
    private bool start;

    void Start()
    {
        script = Tarp.GetComponent<DragTarp>();
        winScreen = false;
        gameOver = false;
        start = false;
    }

    void Update()
    {
        if (!gameOver && !start)
        {
            if (Tarp.transform.position.x < -117f )
            {
                if (GameObject.Find("MiniMusic") != null)
                {
                    GameObject.Find("MiniMusic").SetActive(false);
                }
                Destroy(script);
                Banner.SetActive(false);
                OpenFinalVideo();
                // StartVideo();
                // StartCoroutine(nameof(PlayVideo));
            }
            if (Tarp.transform.position.x > -110f)
            {
                // print("too far left");
                Tarp.transform.position = new Vector3(-113f,107.1427f,-156f);
            }

        }
    }

    public void OpenFinalVideo()
    {
        start = true;
        SceneManager.LoadScene("VideoFinalCorgi", LoadSceneMode.Additive);
        SceneManager.sceneLoaded += StartVideo;
    }

    private void StartVideo(Scene scn, LoadSceneMode lsm)
    {
        // Systems.Status.Pause();
        SceneManager.sceneLoaded -= StartVideo;
        GameObject.Find("FinalCorgiController").GetComponent<PlayVideo>().CloseVideo += CloseVideo;
    }

    private void CloseVideo()
    {
        // Systems.Status.UnPause();
        SceneManager.UnloadSceneAsync("VideoFinalCorgi");
        Win.SetActive(true);
        Tarp.SetActive(false);
        Corgi.SetActive(false);
        Frank.SetActive(false);
        camera.transform.position = new Vector3(-112.58f, 109.9f, -141.5f);
        camera.transform.rotation = Quaternion.Euler(10,180,0);
        GameObject.Find("Mo1").GetComponent<SaveCorgiVisit>().CorgiRescue();
        winScreen = false;
        gameOver = true;


        print("done WINNEr");
    }
}
