using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateSettingsText : MonoBehaviour
{
    public Text settingsText;
    public string preText = "Quality Level:";

    // Start is called before the first frame update
    void Start()
    {
        settingsText.text = preText + " " + QualitySettings.GetQualityLevel();
    }

    // Update is called once per frame
    void Update()
    {
        settingsText.text = preText + " " + QualitySettings.GetQualityLevel();
    }
}
