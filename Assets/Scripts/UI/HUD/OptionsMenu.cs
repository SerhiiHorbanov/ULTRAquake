using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsMenu : MonoBehaviour
{

    public AudioMixer audioMixer;
    float currentVolume;
    public Slider volumeSlide;

    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void SetVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
        currentVolume = volume;
    }

    public void SaveSetting()
    {
        PlayerPrefs.SetFloat("VolumeSet", currentVolume);
    }

    public void Back()
    {
        SceneManager.LoadScene(0);
    }
}
