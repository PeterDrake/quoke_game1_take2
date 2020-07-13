using UnityEngine;
using UnityEngine.SceneManagement;

public class DemoMenu : MonoBehaviour
{
    //loads the scene with the name you give it
    public void loadDemoScene(string sceneName)
    {
        LogToServer logger = GameObject.Find("Logger").GetComponent<LogToServer>();
        logger.sendToLog("Began " + sceneName);
        SceneManager.LoadScene(sceneName);
    }
}
