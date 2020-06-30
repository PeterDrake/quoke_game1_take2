using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleButton : MonoBehaviour
{
    public bool isOn;

    public GameObject handle;
    private RectTransform handleTransform;
    private float handleSize;
    public RectTransform toggle;
    private float onPosX;
    private float offPosX;
    public float handleOffset;

    public GameObject onIcon;
    public GameObject offIcon;

    public float moveSpeed;
    public float t = 0.0f;
    public bool switching = false;


    public void Awake()
    {
        handleTransform = handle.GetComponent<RectTransform>();
        handleSize = handleTransform.sizeDelta.x;
        float toggleSizeX = toggle.sizeDelta.x;
        onPosX = (toggleSizeX / 2) - (handleSize / 2) - handleOffset;
        offPosX = onPosX * -1;

    }
    // Start is called before the first frame update
    void Start()
    {
        if (isOn)
        {
            handleTransform.localPosition = new Vector3(onPosX, 0, 0);
            onIcon.gameObject.SetActive(true);
            offIcon.gameObject.SetActive(false);
        }
        else
        {
            handleTransform.localPosition = new Vector3(offPosX, 0, 0);
            onIcon.gameObject.SetActive(false);
            offIcon.gameObject.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("ON is " + isOn);
        //Debug.Log("switching is " + switching);
        //if (switching)
        //{
        //    StartToggle();
        //}
    }

    public void StartToggle()
    {
        Debug.Log("start");
        //if (!onIcon.activeSelf || !offIcon.activeSelf)
        //{
        //    onIcon.gameObject.SetActive(true);
        //    offIcon.gameObject.SetActive(false);
        //}
        if (isOn)
        {
            handleTransform.localPosition = SmoothlyMove(handle, onPosX, offPosX);
            onIcon.gameObject.SetActive(true);
            offIcon.gameObject.SetActive(false);
        }
        else
        {
            handleTransform.localPosition = SmoothlyMove(handle, offPosX, onPosX);
            onIcon.gameObject.SetActive(false);
            offIcon.gameObject.SetActive(true);
        }
    }

    private Vector3 SmoothlyMove(GameObject handle, float startPosX, float endPosX)
    {
        Vector3 position = new Vector3(Mathf.Lerp(startPosX, endPosX, t += moveSpeed * Time.deltaTime), 0, 0);
        Debug.Log("t = " +t+ moveSpeed  + " " + Time.deltaTime);
        StopSwitching();
        return position;
    }

    public void StopSwitching()
    {
        Debug.Log("done");
        
        if (t > 1)
        {
            switching = false;
            t = 0;
            switch (isOn)
            {
                case true:
                    isOn = false;
                    break;

                case false:
                    isOn = true;
                    break;
            }
        }
    }

    public void isSwitching()
    {
        Debug.Log("Triggered");
        switching = true;
    }
  
}
