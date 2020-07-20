using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DragBarrel : MonoBehaviour
{
     Vector3 startPos;
     Vector3 dist;

    void OnMouseDown()
    {   
        startPos = Camera.main.WorldToScreenPoint(transform.position);
        dist = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, 0.1f, startPos.z));
    }

    void OnMouseDrag()
    {
        Vector3 lastPos = new Vector3(Input.mousePosition.x, 0, startPos.z);
        transform.position = Camera.main.ScreenToWorldPoint(lastPos) + dist;
    }
    
}
