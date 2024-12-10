using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{

    public Slider slider;

    public AudioClip clip;
    public AudioSource audio;

    void Update()
    {
        audio.volume = slider.value;
    }

    public void PlaySound()
    {
        audio.PlayOneShot(clip);
    }
}
