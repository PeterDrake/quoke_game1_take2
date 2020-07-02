using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundToggle : MonoBehaviour
{
    //public bool isOn;

    //public GameObject handle;
    //private RectTransform handleTransform;
    //private float handleSize;
    //public RectTransform toggle;
    //private float onPosX;
    //private float offPosX;
    //private float handleOffset = 75;

    //public GameObject onIcon;
    //public GameObject offIcon;

    //public GameObject sound;

    //public void Awake()
    //{
    //    handleTransform = handle.GetComponent<RectTransform>();
    //    handleSize = handleTransform.sizeDelta.x;
    //    float toggleSizeX = toggle.sizeDelta.x;
    //    onPosX = (toggleSizeX / 2) - (handleSize / 2) - handleOffset;
    //    offPosX = onPosX * -1;

    //}
    //// Start is called before the first frame update
    //void Start()
    //{
    //    if (isOn)
    //    {
    //        handleTransform.localPosition = new Vector3(onPosX, 0, 0);
    //        onIcon.gameObject.SetActive(true);
    //        offIcon.gameObject.SetActive(false);
    //        sound.SetActive(true);
    //    }
    //    else
    //    {
    //        handleTransform.localPosition = new Vector3(offPosX, 0, 0);
    //        onIcon.gameObject.SetActive(false);
    //        offIcon.gameObject.SetActive(true);
    //        sound.SetActive(false);
    //    }
    //}

    //public void StartToggle()
    //{
    //    //if (!onIcon.activeSelf || !offIcon.activeSelf)
    //    //{
    //    //    onIcon.gameObject.SetActive(true);
    //    //    offIcon.gameObject.SetActive(false);
    //    //}
    //    if (isOn)
    //    {
    //        Debug.Log("music off");
    //        handleTransform.localPosition = SmoothlyMove(onPosX, offPosX);
    //        onIcon.gameObject.SetActive(false);
    //        offIcon.gameObject.SetActive(true);
    //        sound.SetActive(false);
    //    }
    //    else
    //    {
    //        Debug.Log("music on");
    //        handleTransform.localPosition = SmoothlyMove(offPosX, onPosX);
    //        onIcon.gameObject.SetActive(true);
    //        offIcon.gameObject.SetActive(false);
    //        sound.SetActive(true);
    //    }
    //}

    //private Vector3 SmoothlyMove(float startPosX, float endPosX)
    //{
    //    Vector3 position = new Vector3(Mathf.Lerp(startPosX, endPosX, 1), 0, 0);
    //    switch (isOn)
    //    {
    //        case true:
    //            isOn = false;
    //            break;

    //        case false:
    //            isOn = true;
    //            break;
    //    }
    //    return position;
    //}
}
