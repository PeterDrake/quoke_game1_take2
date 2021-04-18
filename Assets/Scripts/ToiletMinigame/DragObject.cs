using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragObject : MonoBehaviour
{
    private Vector3 mOffset;
    public bool inBox = false;
    // private String lastCollison = "mouse released with no placements";
    private float mZCoord;
    private Vector3 place;
    private Vector3 home;
    public GameObject box;
    private LogToServer logger;

    //at the beginning save starting position as home vector & logging stuff
    private void Awake()
    {
        home = this.transform.position;
        logger = GameObject.Find("Logger").GetComponent<LogToServer>();
    }

    //on click find mouse & screen offset
    void OnMouseDown()
    {
        if (box != null)
        {
            box.GetComponent<BoxCollider>().enabled = true;
        }
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

    private void OnMouseUp()
    {
        if (inBox)
        {
            //Move Position
            PlaceItem(box.transform.position);
            Debug.Log("placed in box");
        }
        else
        {
            PlaceItem(home);
            Debug.Log("placed in home");
        }
    }

    public void OnTriggerStay(Collider other)
    {
        inBox = true;
        box = other.gameObject;
    }

    public void OnTriggerExit(Collider other)
    {
        inBox = false;
        box = null;
    }

    public void PlaceItem(Vector3 newPosition)
    {
        if (box != null)
        {
            
            this.transform.position = new Vector3(newPosition.x, home.y, newPosition.z);
            if(tag == "Poop")
            {
                this.transform.position = new Vector3(newPosition.x+ .1f , home.y - .2f, newPosition.z-.6f);
            }
            if (tag == "Bucket")
            {
                this.transform.position = new Vector3(newPosition.x, home.y-.1f, newPosition.z);
            }
            if (tag == "ToiletPaper")
            {
                this.transform.position = new Vector3(newPosition.x +.2f, home.y - .1f, newPosition.z);
            }
            // logger.sendToLog(this.name + " placed in " + lastCollison,"MINIGAME");
            // Debug.Log(this.name +" is placed in the "+ box.name);
        }
        else
        {
            this.transform.position = home;
            // Debug.Log(this.name + " got sent back home");

        }
    }
}
