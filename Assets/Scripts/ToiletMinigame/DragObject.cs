using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 mOffset;

    private String lastCollison = "mouse released with no placements";

    private float mZCoord;


    private LogToServer logger;

    private void Awake()
    {
        logger = GameObject.Find("Logger").GetComponent<LogToServer>();
    }

    void OnMouseDown()

    {

        mZCoord = Camera.main.WorldToScreenPoint(

            gameObject.transform.position).z;



        // Store offset = gameobject world pos - mouse world pos

        mOffset = gameObject.transform.position - GetMouseAsWorldPoint();

    }
    private Vector3 GetMouseAsWorldPoint()

    {

        // Pixel coordinates of mouse (x,y)

        Vector3 mousePoint = Input.mousePosition;



        // z coordinate of game object on screen

        mousePoint.z = mZCoord;



        // Convert it to world points

        return Camera.main.ScreenToWorldPoint(mousePoint);

    }



    void OnMouseDrag()

    {

        transform.position = GetMouseAsWorldPoint() + mOffset;

    }


    public void SetLastCollision(string boxName)
    {
        lastCollison = boxName;
    }

    private void OnMouseUp()
    {
        Debug.Log(this.name + " placed in " + lastCollison);
        logger.sendToLog(this.name + " placed in " + lastCollison);
    }
}
