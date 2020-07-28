using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class LogToServer : Singleton<LogToServer>
{
    
    private String message = "Message for log";
    private String postURL = "/dbenter.php";

    public string loggername;
    // Start is called before the first frame update

    private void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        Debug.Log("Logger started: " + loggername);
    }

    // Update is called once per frame

    public void sendToLog(String message)
    {
       
        StartCoroutine(PostRequest(message));
    }

    IEnumerator PostRequest(String message)
    {
        Debug.Log("Sending post request using logger: " + loggername);
        List<IMultipartFormSection> wwwForm = new List<IMultipartFormSection>();
        wwwForm.Add(new MultipartFormDataSection("message", message));
        
        //Get time in game and add to post request
        int time = (int) Math.Round(Time.realtimeSinceStartup);
        wwwForm.Add(new MultipartFormDataSection("gametime", time.ToString()));

        UnityWebRequest www = UnityWebRequest.Post(postURL, wwwForm);

        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.LogError(www.error);
        }
        else
        {
            Debug.Log("Logged successfully");
        }
        
    }
    
}