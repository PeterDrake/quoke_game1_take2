using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LogPlayerLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LogToServer logger = GameObject.Find("Logger").GetComponent<LogToServer>();
        logger.sendToLog("Loaded " + SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    /*void Update()
    {
        
    }*/
}
