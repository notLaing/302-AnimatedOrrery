using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class UI : MonoBehaviour
{
    public AudioMixer audioMixer;
    public bool rewinding = false;

    public void Play()
    {
        Time.timeScale = 1f;
        rewinding = false;
    }

    public void FastForward()
    {
        Time.timeScale = 2f;
        rewinding = false;
    }

    public void Pause()
    {
        Time.timeScale = 0f;
        rewinding = false;
    }

    public void Rewind()
    {
        Time.timeScale = 1f;
        rewinding = true;
    }

    public void SetVolume(float vol)
    {
        audioMixer.SetFloat("Volume", vol);
    }
}
