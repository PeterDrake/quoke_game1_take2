using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlatFollow : MonoBehaviour
{
    public GameObject following;
    public float height;
    public bool mobile;
    public bool startReal;

    public float westBound;
    public float eastBound;
    public float northBound;
    public float southBound;

    private float theX;
    private float theZ;

    private Transform location;
    private Color realColor;
    private Color clearColor;

    // Start is called before the first frame update
    void Start()
    {
        location = GetComponent<Transform>();
        location.transform.position = new Vector3
            (following.transform.position.x, height, following.transform.position.z);
        realColor = GetComponent<SpriteRenderer>().color;
        clearColor = Color.clear;
        if (!startReal) { disappear(); }
    }

    // Update is called once per frame
    void Update()
    {
        if (mobile)
        {
            StartCoroutine(follow());
        }
    }

    private IEnumerator follow()
    {
        while (true)
        {
            if (following.transform.position.x < westBound) { theX = westBound; }
            else if (following.transform.position.x > eastBound) { theX = eastBound; }
            else { theX = following.transform.position.x; }

            if (following.transform.position.z > southBound) { theZ = southBound; }
            else if (following.transform.position.z < northBound) { theZ = northBound; }
            else { theZ = following.transform.position.z; }


            location.transform.position = new Vector3
                (theX, height, theZ);
            yield return new WaitForSeconds(0.01f);
        }
    }

    public void appear()
    {
        GetComponent<SpriteRenderer>().color = realColor;
    }
    public void disappear()
    {
        GetComponent<SpriteRenderer>().color = clearColor;
    }
}
