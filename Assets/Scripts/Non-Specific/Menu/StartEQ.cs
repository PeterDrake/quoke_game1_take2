using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.UI;

public class StartEQ : MonoBehaviour
{
    public GameObject eqSound;
    public GameObject ding;
    public Image wave;
    public GameObject button;
    public GameObject tree;
    public CinemachineVirtualCamera VirtualCamera;
    private CinemachineBasicMultiChannelPerlin virtualCameraNoise;


    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("start");
        virtualCameraNoise = VirtualCamera.GetCinemachineComponent<Cinemachine.CinemachineBasicMultiChannelPerlin>();
        StartCoroutine("Read");
    }

    public IEnumerator Read()
    {
        Debug.Log("im reading");
        yield return new WaitForSeconds(2f);
        StartCoroutine("ShakeCamera");
        StartCoroutine("Wave");
        eqSound.SetActive(true);
        

    }
    IEnumerator Wave()
    {
        float time = 5;
        while (time > 0)
        {
            wave.fillAmount += .04f;
            yield return new WaitForSeconds(.2f);
            time -= .2f;
        }
        
    }

    IEnumerator ShakeCamera()
    {
        Debug.Log("starting to shake");
        virtualCameraNoise.m_AmplitudeGain = 3f;
        virtualCameraNoise.m_FrequencyGain = 3f;
        tree.AddComponent<Rigidbody>();
        yield return new WaitForSeconds(5f);
   
        Debug.Log("done eq");
        eqSound.SetActive(false);
        virtualCameraNoise.m_AmplitudeGain = 0f;
        virtualCameraNoise.m_FrequencyGain = 0f;
        button.SetActive(true);
        ding.SetActive(true);
    }


    public void PlayButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }
}

