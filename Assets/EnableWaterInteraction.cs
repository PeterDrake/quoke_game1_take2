using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableWaterInteraction : MonoBehaviour
{

    public GameObject Water;
    public GameObject Steam;
    public GameObject Pot;
    private InteractWithObject script;
    private int check = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        script = Water.GetComponent<InteractWithObject>();
        //StartCoroutine(nameof(EnableScript));
    }

    void Update()
    {
        if (!Steam.activeSelf && Pot.activeSelf && check == 0)
        {
            script.enabled = true;
            check = 1;
        }
    }

    private IEnumerator EnableScript()
    {
        yield return new WaitForSeconds(7f);
        script.enabled = true;
    }

}
