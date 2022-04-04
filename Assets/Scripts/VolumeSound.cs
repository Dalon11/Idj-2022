using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSound : MonoBehaviour
{
    public AudioSource soundMusic;
    Slider slider; 

    void Start()
    {
        soundMusic = Music.Instance.gameObject.GetComponent<AudioSource>();
        slider = GetComponent<Slider>();
    }
    public void Volume()
    {
        soundMusic.volume = slider.value;
    }
}
