using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Threading;

/// <summary>
/// Manager class for killing the player and displaying death screen 
/// </summary>
public class DeathDisplay : UIElement
{ 
    public GameObject toggle;
    public Text deathText;
    public float waitTime;

    private bool dead;
   
    public void Start()
    {
       //pauseOnOpen = true;
       forceOpen = true;
       locked = true;
       toggle.SetActive(false);
    }
    public void RestartLevel()
    {
        string currentSceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(currentSceneName);
    }

    public void Activate(string text)
    { 
        deathText.text = text;
        StartCoroutine(nameof(WaitThenShow), waitTime);
    }

    private IEnumerator WaitThenShow(float time)
    {
        while (time>0)
        {
            yield return new WaitForSeconds(1f);
            time--;
        }
        UIManager.Instance.SetAsActive(this);
    }

    public override void Open()
    {
        toggle.SetActive(true);
    }

    public override void Close()
    {
        toggle.SetActive(false);
    }
}
