using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class MiniGameMasterPitLatrine : MonoBehaviour
{
    public GameObject Camera;

    //public bool UseClicked;
    private bool check;

    public Button PlywoodButton;
    public Button TarpButton;
    public GameObject PButton;
    public GameObject TButton;

    public UnityAction OnWin;
    public UnityAction OnExit;
    public GameObject Win;
    public GameObject WinSound;

    public GameObject S1Folder;
    public GameObject S2Folder;
    public GameObject S1Pit1;
    public GameObject S1Pit2;
    public GameObject Water;
    public GameObject S2Pit1;
    public GameObject S2Pit2;
    public GameObject S2Pit3;
    public GameObject Shovel2;
    public GameObject Tarp;
    public GameObject Plywood;

    public GameObject BuildError;
    public Text BuildErrorText;
    public GameObject ErrorScreen;
    public GameObject TryHighGround;
    public GameObject ErosionScreen;
    public GameObject WinScreen;
    public GameObject Depth1;
    public GameObject Depth2; //Depths 3 and 4 are regulated in MoveOtherShovel script
    //public GameObject Depth3;
    //public GameObject Depth4;
    //public GameObject Depth5;

    //public GameObject Use;
    public GameObject Dig; //Button for S1
    public GameObject Dig2; //Button for S2

    public GameObject Dirt1;
    public GameObject Dirt2;
    public GameObject Dirt3;
    public GameObject Dirt4;


    public void Start()
    {
        //PlywoodButton.GetComponent<Button>().interactable = false;
        //TarpButton.GetComponent<Button>().interactable = false;
        PlywoodButton.GetComponent<Button>().onClick.AddListener(NoBuildPly);
        TarpButton.GetComponent<Button>().onClick.AddListener(NoBuildTarp);

        if (S1Folder.activeSelf)
        {
            Camera.transform.position = new Vector3(72.409f, 1.763f, -139.003f);
            S1Folder.SetActive(true);
            S2Folder.SetActive(false);
            Dig.SetActive(true);
            Dig2.SetActive(false);
        }

        else
        {
            Camera.transform.position = new Vector3(77.6f, 2.9f, -134.4f);
            S1Folder.SetActive(false);
            S2Folder.SetActive(true);
            Dig.SetActive(false);
            Dig2.SetActive(true);
        }
    }

    public void Update()
    {
        if (S1Folder.activeSelf)
        {
            if (S1Pit1.activeSelf)
            {
                Depth1.SetActive(true);
            }

            if (S1Pit2.activeSelf)
            {
                Depth2.SetActive(true);
            }

            /*if (S1Pit2.activeSelf == false && UseClicked)
            {
                StartCoroutine(nameof(TooShallow));
            }*/

            if (Water.activeSelf)
            {
                //Use.SetActive(false);
                Dig.SetActive(false);
                PButton.SetActive(false);
                TButton.SetActive(false);
                StartCoroutine(nameof(TryElsewhere));
            }
        }

        else
        {
            /*if (!S2Pit2.activeSelf && !S2Pit3.activeSelf && UseClicked)
            {
                StartCoroutine(nameof(TooShallow));
            }*/

            if (Depth2.activeSelf)
            {
                Depth1.SetActive(false);
                PlywoodButton.GetComponent<Button>().onClick.RemoveListener(NoBuildPly);
                PlywoodButton.GetComponent<Button>().onClick.AddListener(PlyBuild);
            }

            if (Plywood.activeSelf)
            {
                //TarpButton.GetComponent<Button>().interactable = true;
                PlywoodButton.GetComponent<Button>().interactable = false;
                Dig2.GetComponent<Button>().interactable = false;
                Shovel2.SetActive(false);
                S2Pit2.SetActive(false);
                S2Pit1.SetActive(false);
                TarpButton.GetComponent<Button>().onClick.RemoveListener(NoBuildTarp);
                TarpButton.GetComponent<Button>().onClick.AddListener(TarpBuild);
                //if (Tarp.activeSelf)
                //{
                //    TarpButton.GetComponent<Button>().interactable = false;
                //}
            }

            if (Tarp.activeSelf) //&& UseClicked)
            {
                //Use.SetActive(false);
                //Dig2.SetActive(false);
                TarpButton.GetComponent<Button>().interactable = false;
                StartCoroutine(nameof(Winning));
                //WinScreen.SetActive(true);
            }

            //if (S2Pit2.activeSelf && !S2Pit3.activeSelf)
            //{
            //    PlywoodButton.GetComponent<Button>().interactable = true;
            //}

            if (S2Pit3.activeSelf && !check)
            {
                check = true;
                StartCoroutine(nameof(TooDeep));
            }

            if (!S2Pit3.activeSelf)
            {
                check = false;
            }
        }
    }

    /*private IEnumerator TooShallow()
    {
        ErrorScreen.SetActive(true);
        yield return new WaitForSeconds(4f);
        ErrorScreen.SetActive(false);
        UseClicked = false;
    }*/

    private IEnumerator Winning()
    {
        yield return new WaitForSeconds(1f);
        WinScreen.SetActive(true);
        WinSound.SetActive(true);
        
    }

    private IEnumerator TooDeep()
    {
        Dig2.SetActive(false);
        //Use.SetActive(false);
        PButton.SetActive(false);
        TButton.SetActive(false);
        
        yield return new WaitForSeconds(3f);
        ErosionScreen.SetActive(true);
        yield return new WaitForSeconds(3f); 
        ErosionScreen.SetActive(false);
        Dig2.SetActive(true);
        //Use.SetActive(true);
        PButton.SetActive(true);
        TButton.SetActive(true);
        PlywoodButton.GetComponent<Button>().onClick.RemoveListener(PlyBuild);
        PlywoodButton.GetComponent<Button>().onClick.AddListener(NoBuildPly);
        TarpButton.GetComponent<Button>().onClick.RemoveListener(TarpBuild);
        TarpButton.GetComponent<Button>().onClick.AddListener(NoBuildTarp);
        Dirt1.SetActive(false);
        Dirt2.SetActive(false);
        Dirt3.SetActive(false);
        Dirt4.SetActive(false);
        Depth1.SetActive(false);
        S2Pit1.SetActive(false);

        //PlywoodButton.GetComponent<Button>().interactable = false;
    }

    private void UseIsClicked()
    {
        //UseClicked = true;
    }
    
    private IEnumerator TryElsewhere()
    {
        yield return new WaitForSeconds(3f);
        TryHighGround.SetActive(true);
        //UseClicked = false;
    }

    private void PlyBuild()
    {
        Plywood.SetActive(true);
    }

    private void TarpBuild()
    {
        Tarp.SetActive(true);
    }

    public void NoBuildPly()
    {
        BuildErrorText.text = "You need a bigger hole. Keep Digging";
        StartCoroutine(BuildErrorMessage());
    }

    public void NoBuildTarp()
    {
        BuildErrorText.text = "Add some plywood before setting up the tarp";
        StartCoroutine(BuildErrorMessage());
    }

    private IEnumerator BuildErrorMessage()
    {
        BuildError.SetActive(true);
        yield return new WaitForSeconds(3f);
        BuildError.SetActive(false);
    }

    public void Leave()
    {
        OnExit.Invoke();
    }
    
    public void WinLeave()
    {
        OnWin.Invoke();
    }

}
