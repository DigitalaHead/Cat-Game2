using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    [SerializeField] AudioSource musicSource;
    [SerializeField] AudioSource SFXSource;

    public Slider MusicSlider;
    public Slider SFXSlider;

    public AudioClip background;
    public AudioClip jump;
    public AudioClip death;

    void Update()
    {
        musicSource.volume = MusicSlider.value;
        SFXSource.volume = SFXSlider.value;
    }

    private void Start()
    {
        musicSource.clip = background;
        musicSource.Play();
    }

    public void PlaySFX(AudioClip clip)
    {
        SFXSource.PlayOneShot(clip);
    }

}
