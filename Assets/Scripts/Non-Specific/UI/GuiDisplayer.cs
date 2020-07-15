using UnityEngine;

/// <summary>
/// A manager to keep track of GUI elements (status bars, text banner, interact text & misc buttons (inventory))
/// </summary>
public class GuiDisplayer : UIElement
{
    private GameObject toggler;
    [SerializeField] private InformationCanvas Banner;
    [SerializeField] private InformationCanvas Interact;

    private bool musicIsOff;
    private bool sfxIsOff;
    
    private void Start()
    {
        toggler = transform.Find("GUIToggler").gameObject;
       UIManager.Instance.Initialize(this);

        print("GUI start method");

        musicIsOff = SavedData.musicOff;
        if (!musicIsOff)
        {
            Debug.Log("music turned on");
            GameObject.Find("Audio").SetActive(true);
        }
        else
        {
            Debug.Log("music turned off");
            GameObject.Find("Audio").SetActive(false);
        }
        sfxIsOff = SavedData.sfxOff;
        if (!sfxIsOff)
        {
            Debug.Log("soundFX turned on");
            GameObject.Find("SoundFX").SetActive(true);
        }
        else
        {
            Debug.Log("soundFX turned off");
            GameObject.Find("SoundFX").SetActive(false);
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

    public InformationCanvas GetBanner()
    {
        return Banner;
    }
    
    public InformationCanvas GetInteract()
    {
        return Interact;
    }
}