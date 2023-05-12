using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class game_music : MonoBehaviour
{
    private AudioSource audioSrc;
    private float musicVolume = 1f;
    void Start()
    {
        audioSrc = GetComponent<AudioSource>();
    }

    void Update()
    {
        audioSrc.volume = musicVolume;
    }
    public void SetVolume(float vol)
    {
        musicVolume = vol;

    }
    public void mute()
    {
        musicVolume = 0;
    }
    public void audio()
    {
        musicVolume = 1;
    }
}
