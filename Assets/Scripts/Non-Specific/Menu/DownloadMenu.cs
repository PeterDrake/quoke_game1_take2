using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DownloadMenu: MonoBehaviour

{
    private Downloads downloader;
    private Image icon;
    public Button button;

    //loads the scene with the name you give it
    public void downloadResource(string docname)
    {
    Application.OpenURL("/downloadHandout.php/?docname="+docname);
    /*
        downloader = GameObject.Find("Downloader").GetComponent<Downloads>();
        downloader.sendToLog(docname); */
        icon = gameObject.GetComponent<Image>();
        /*
        downloader = GameObject.Find("Downloader").GetComponent<Downloads>();
        downloader.sendToLog(docname);
        */
        icon.color = Color.green;
        button.interactable = false;
    }
}
