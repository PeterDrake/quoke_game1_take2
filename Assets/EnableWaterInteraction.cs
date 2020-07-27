using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableWaterInteraction : MonoBehaviour
{

    public GameObject Water;
    private InteractWithObject script;
    
    // Start is called before the first frame update
    void Start()
    {
        script = Water.GetComponent<InteractWithObject>();
        StartCoroutine(nameof(EnableScript));
    }

    private IEnumerator EnableScript()
    {
        yield return new WaitForSeconds(7f);
        script.enabled = true;
    }

}
