using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlatFollow : MonoBehaviour
{
    public GameObject following;
    [Header("Height of camera: 13.5, Height of Chars: 1.7")]
    public float height;
    public bool mobile;
    public bool startReal;

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
            location.transform.position = new Vector3
                (following.transform.position.x, height, following.transform.position.z);
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
