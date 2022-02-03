using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class UI : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Transform subaru, ina, ame, gura, kiara, calli;
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

    public void LookAt(int select)
    {
        OrbitCameraRig cam = FindObjectOfType<OrbitCameraRig>();
        switch(select)
        {
            case 0://all
                cam.target = subaru;
                break;
            case 1://Calli
                cam.target = calli;
                break;
            case 2://Kiara
                cam.target = kiara;
                break;
            case 3://Gura
                cam.target = gura;
                break;
            case 4://Ame
                cam.target = ame;
                break;
            case 5://Ina
                cam.target = ina;
                break;
        }
    }
}
