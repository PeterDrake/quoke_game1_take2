using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateSettingsText : MonoBehaviour
{
    public Text settingsText;
    public string preText = "Quality Level:";
    public string[] qualityLevels = new string[] { "Very Low", "Low", "Medium", "High", "Very High", "Ultra" };

    // Start is called before the first frame update
    void Start()
    {
        settingsText.text = preText + " " + qualityLevels[QualitySettings.GetQualityLevel()];
    }

    // Update is called once per frame
    void Update()
    {
        settingsText.text = preText + " " + qualityLevels[QualitySettings.GetQualityLevel()];
    }
}
