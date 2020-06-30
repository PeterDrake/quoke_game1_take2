using UnityEngine;
using UnityEngine.SceneManagement;
using Button = UnityEngine.UI.Button;

/// <summary>
/// Manages the Menu, containing buttons such as Exit to Menu, Exit Game, Settings, and Inventory
/// </summary>
public class MenuDisplayer : UIElement
{
    public int mainMenuSceneIndex;

    private GameObject menuOptions;
    private GameObject settingOptions;
    private GameObject toggler;
    private Transform volume;
    private Transform buttons;

    private ToggleButton music;

    private void initialize()
    {
        toggler = transform.Find("toggle").gameObject;
        menuOptions = toggler.transform.Find("buttons").gameObject;
        settingOptions = toggler.transform.Find("volume").gameObject;
        buttons = toggler.transform.Find("buttons");
        volume = toggler.transform.Find("volume");
  

        foreach (Transform child in buttons)
        {
            switch (child.name)
            {
                case "close":
                    child.GetComponent<Button>().onClick.AddListener(delegate { UIManager.Instance.ToggleActive(this); });
                    break;
                case "exit":
                    child.GetComponent<Button>().onClick.AddListener(Application.Quit);
                    break;
                case "mainMenu":
                    child.GetComponent<Button>().onClick.AddListener(mainMenu);
                    break;
                case "settings":
                    child.GetComponent<Button>().onClick.AddListener(settings);
                    break;
            }

        }

        foreach (Transform child in volume)
        {
            switch (child.name)
            {
                case "musicToggle":
                    music = child.GetComponent<ToggleButton>();
                    child.transform.Find("button").GetComponent<Button>().onClick.AddListener(child.GetComponent<ToggleButton>().StartToggle);
                    break;
                case "fxToggle":
                    break;
                case "back":
                    child.GetComponent<Button>().onClick.AddListener(backToMenu);
                    break;
            }
        }
    }
    private void Start()
    {
        locked = true;
        pauseOnOpen = true;
        Systems.Input.RegisterKey("escape",delegate {UIManager.Instance.ToggleActive(this); });
        initialize();
        toggler.SetActive(false);
    }

    public override void Open()
    {
        toggler.SetActive(true);
    }

    public override void Close()
    {
        toggler.SetActive(false);
    }

    private void mainMenu()
    {
        SceneManager.LoadScene(mainMenuSceneIndex);
    }

    private void settings()
    {
        menuOptions.SetActive(false);
        settingOptions.SetActive(true);
    }

    private void backToMenu()
    {
        menuOptions.SetActive(true);
        settingOptions.SetActive(false);
    }

    private void move()
    {
        if (music.isOn)
        {
            Debug.Log("music on");
        }
        else
        {
            Debug.Log("music off");
        }
    }

}