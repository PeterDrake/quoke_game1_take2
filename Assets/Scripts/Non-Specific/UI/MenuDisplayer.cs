using UnityEngine;
using UnityEngine.SceneManagement;
using Button = UnityEngine.UI.Button;

/// <summary>
/// Manages the Menu, containing buttons such as Exit to Menu, Exit Game, Settings, and Inventory
/// </summary>
public class MenuDisplayer : UIElement
{
    public int mainMenuSceneIndex;
    
    // toggler, exitToMenu, quitGame, Settings, Inventory 

    private GameObject toggler;
    private bool escCanviToggler;
    private GameObject escCanvi;


    private void Start()
    {
        locked = true;
        pauseOnOpen = true;
        escCanviToggler = false;
        Systems.Input.RegisterKey("escape", delegate {
            if (escCanviToggler)
            {
                escCanvi.SetActive(false);
            }
            else
            {
                UIManager.Instance.ToggleActive(this);
            }
        });
        initialize();
        toggler.SetActive(false);
    }

    public void openCanvi(GameObject theCanvi)
    {
        escCanvi = theCanvi;
        escCanviToggler = true;
    }
    public void closeCanvi()
    {
        escCanviToggler = false;
    }

    private void initialize()
    {
        toggler = transform.Find("toggle").gameObject;
        Transform buttons = toggler.transform.Find("buttons"); 
        
        foreach (Transform child in buttons)
        {
            switch (child.name)
            {
                case "close":
                    child.GetComponent<Button>().onClick.AddListener(delegate {UIManager.Instance.ToggleActive(this); });
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

    private void settings() { }
}