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
    private GameObject last;

    private LogToServer logger;

    private void Awake()
    {
        home = this.transform.position;

        logger = GameObject.Find("Logger").GetComponent<LogToServer>();
    }

    void OnMouseDown()

    {
        if (last != null)
        {
            last.GetComponent<BoxCollider>().enabled = true;
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


    public void SetLastCollision(string boxName)
    {
        lastCollison = boxName;
    }

    private void OnMouseUp()
    {
        

        if (inBox)
        {
            last = GameObject.Find(lastCollison);
            place = last.transform.position;
            this.transform.position = new Vector3(place.x, home.y, place.z);
            if(tag == "Poop")
            {
                this.transform.position = new Vector3(place.x+ .1f , home.y - .2f, place.z-.6f);
            }
            if (tag == "Bucket")
            {
                this.transform.position = new Vector3(place.x, home.y-.1f, place.z);
            }
            if (tag == "ToiletPaper")
            {
                this.transform.position = new Vector3(place.x +.2f, home.y - .1f, place.z);
            }
            last.GetComponent<MiniGameCheck>().StatusCheck(this.GetComponent<Collider>());
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
