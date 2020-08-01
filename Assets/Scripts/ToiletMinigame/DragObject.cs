using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 mOffset;
    public bool inBox = false;

    private String lastCollison = "mouse released with no placements";

    private float mZCoord;

    private Vector3 place;
    private Vector3 home;

    private LogToServer logger;

    private void Awake()
    {
        home = this.transform.position;
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
        print("m offset ==== " + mOffset);

    }


    public void SetLastCollision(string boxName)
    {
        lastCollison = boxName;
    }

    private void OnMouseUp()
    {
        if (inBox)
        {
            place = GameObject.Find(lastCollison).transform.position;
            this.transform.position = new Vector3(place.x, place.y, place.z);

        }
        else if (!inBox)
        {
            this.transform.position = home;
            
            SetLastCollision("Home");
        }
        print("PLACE OF THIS OBKECT IS " + place);
        Debug.Log(this.name + " placed in " + lastCollison);
        logger.sendToLog(this.name + " placed in " + lastCollison);
    }
}
