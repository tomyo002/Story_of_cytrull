using UnityEngine.Audio;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.Linq;

public class SettingMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Dropdown resolutionDropdown;

    Resolution[] resolutions;
    public Slider musicSlider;
    public Slider soundSlider;

    public void Start()
    {
        audioMixer.GetFloat("music", out float musicValueForSlider);
        musicSlider.value = musicValueForSlider;

        audioMixer.GetFloat("sound", out float soundValueForSlider);
        soundSlider.value = soundValueForSlider;
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        List<string> options = new List<string>();

        int currentResolutionIndex = 0;
        for (int i =0; i <resolutions.Length; i++)
        {
            string option = resolutions[i].width +"x" +resolutions[i].height;
            options.Add(option);

            if(resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;

            }
        }  
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        Screen.fullScreen = true;    
    }

    public void SetVolume(float Volume)
    {
        audioMixer.SetFloat("music", Volume);
    }
    public void SetSound(float Volume)
    {
        audioMixer.SetFloat("sound", Volume);
    }

    public void SetFullScreen(bool IsFullScreen)
    {
        Screen.fullScreen =IsFullScreen ;
    }
    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
     public void ResetG()
    {
        PlayerPrefs.DeleteAll();
    }
}
