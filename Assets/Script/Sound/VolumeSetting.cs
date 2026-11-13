using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class VolumeSetting : MonoBehaviour
{
    [SerializeField] private AudioMixer mainMixer;
    [SerializeField] private Slider musicSlider;
    [SerializeField] private Slider SFXSLider;
    [SerializeField] private Slider masterSlider;

    private void Start()
    {
        if (PlayerPrefs.HasKey("musicVolume"))
        {
            LoadVolume();
        }
        else
        {
            SetMusicVolume();
        }
    }
    public void SetMusicVolume()
    {
        float musicVolume = musicSlider.value;
        mainMixer.SetFloat("Music", Mathf.Log10(musicVolume) * 20);
        PlayerPrefs.SetFloat("musicVolume", musicVolume);
    }
    public void SetSFXVolume()
    {
        float SFXVolume = SFXSLider.value;
        mainMixer.SetFloat("SFX", Mathf.Log10(SFXVolume) * 20);
        PlayerPrefs.SetFloat("SFXVolume", SFXVolume);

    }
    public void SetMasterVolume()
    {
        float masterVolume = masterSlider.value;
        mainMixer.SetFloat("Master", Mathf.Log10(masterVolume) * 20);
        PlayerPrefs.SetFloat("masterVolume", masterVolume);
    }
    private void LoadVolume()
    {
        musicSlider.value = PlayerPrefs.GetFloat("musicVolume");
        SFXSLider.value = PlayerPrefs.GetFloat("SFXVolume");
        masterSlider.value = PlayerPrefs.GetFloat("masterVolume");
        SetMusicVolume();
    }
}
