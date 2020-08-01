using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveNeck : MonoBehaviour
{

    public GameObject Neck; // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(nameof(MoveTheNeck));
    }

    private IEnumerator MoveTheNeck()
    {
        yield return new WaitForSeconds(5f);
        Neck.transform.Rotate(0, 34, 0);
    }
}
