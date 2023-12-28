using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundControll : MonoBehaviour
{
    [SerializeField]
    Slider slider;
    AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(slider.value != audioSource.volume)
        {
            slider.value = audioSource.volume;
        }
    }
}
