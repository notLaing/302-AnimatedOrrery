using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class UI : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Transform subaru, ina, ame, gura, kiara, calli;
    public GameObject orbitCam, flightCam;
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
        OrbitCameraRig cam = orbitCam.GetComponent<OrbitCameraRig>();
        switch(select)
        {
            case 0://all
                orbitCam.SetActive(false);
                flightCam.SetActive(true);
                //cam.target = subaru;
                break;
            case 1://Calli
                flightCam.SetActive(false);
                orbitCam.SetActive(true);
                orbitCam.GetComponent<OrbitCameraRig>().target = calli;
                break;
            case 2://Kiara
                flightCam.SetActive(false); 
                orbitCam.SetActive(true);
                orbitCam.GetComponent<OrbitCameraRig>().target = kiara;
                break;
            case 3://Gura
                flightCam.SetActive(false); 
                orbitCam.SetActive(true);
                orbitCam.GetComponent<OrbitCameraRig>().target = gura;
                break;
            case 4://Ame
                flightCam.SetActive(false); 
                orbitCam.SetActive(true);
                orbitCam.GetComponent<OrbitCameraRig>().target = ame;
                break;
            case 5://Ina
                flightCam.SetActive(false); 
                orbitCam.SetActive(true);
                orbitCam.GetComponent<OrbitCameraRig>().target = ina;
                break;
            case 6://all
                flightCam.SetActive(false); 
                orbitCam.SetActive(true);
                orbitCam.GetComponent<OrbitCameraRig>().target = subaru;
                break;
        }
    }
}
