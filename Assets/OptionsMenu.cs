using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OptionsMenu : MonoBehaviour
{
    public AudioSource AS;
    Resolution[] resolutions;
    public Dropdown resolutioDropdown;
    private void Start()
    {
        resolutions = Screen.resolutions;
        resolutioDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currResindex = 0;
        for(int i =0;i < resolutions.Length;i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if(resolutions[i].width==Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currResindex = i;
            }
        }
        resolutioDropdown.AddOptions(options);
        resolutioDropdown.value = currResindex;
        resolutioDropdown.RefreshShownValue();
    }
    public void SetVolum(float volum)
    {
        AS.volume = volum / 10;
    }
    public void SetQuality(int QualityIndex)
    {
        QualitySettings.SetQualityLevel(QualityIndex);
    }
    public void SetFullScreen (bool isFullScreen)
    {
        Screen.fullScreen = isFullScreen;
    }
    public void SetResolution(int ResolutionIndex)
    {
        Resolution resolution = resolutions[ResolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
}
