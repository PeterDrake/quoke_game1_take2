using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoveToggle : MonoBehaviour
{

    public bool isOn;
    public GameObject handle;
    private RectTransform handleTransform;
    private float handleSize;
    public GameObject toggleBackground;
    private RectTransform toggleTransform;
    private float onPosX;
    private float offPosX;
    public float handleOffset;
    public Text status;
    public GameObject sound;

    // Start is called before the first frame update
    void Start()
    {
        isOn = true;
        handleTransform = handle.GetComponent<RectTransform>();
        toggleTransform = handle.GetComponent<RectTransform>();
        handleSize = handleTransform.sizeDelta.x;
        float toggleSizeX = toggleTransform.sizeDelta.x;
        onPosX = (toggleSizeX / 2) - (handleSize / 2) - handleOffset;
        offPosX = onPosX * -1;
    }

    public void StartToggle()
    {
        isOn = !isOn;
        if (isOn)
        {
            Debug.Log("toggle turned on");
            handleTransform.localPosition = new Vector3(onPosX, toggleTransform.localPosition.y, 0);
            status.text = "ON";
            sound.SetActive(true);
        }
        else
        {
            Debug.Log("toggle turned off");
            handleTransform.localPosition = new Vector3(offPosX, toggleTransform.localPosition.y, 0);
            status.text = "OFF";
            sound.SetActive(false);
        }

 
    }
}
