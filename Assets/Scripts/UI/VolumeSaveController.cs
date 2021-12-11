using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSaveController : MonoBehaviour
{
    //public Toggle musicToggle;
    //public Toggle soundsToggle;

    private void Start()
    {
        //ToggleMusic();
        //ToggleVolume();
    }

    public void ToggleMusic()
    {
        if (AudioManager.instance.isMusicEnabled)
        {
            AudioManager.instance.isMusicEnabled = false; // este setnut toggle
            //musicToggle.isOn = false;
        } else
        {
            AudioManager.instance.isMusicEnabled = true; //set toggle
            //musicToggle.isOn = true;
        }

        AudioManager.instance.PlayMusic("menu_music");

    }

    public void ToggleVolume()
    {
        if (AudioManager.instance.isSoundEnabled)
        {
            AudioManager.instance.isSoundEnabled = false; // este setnut toggle
            //soundsToggle.isOn = false;
        }
        else
        {
            AudioManager.instance.isSoundEnabled = true; //set toggle
            //soundsToggle.isOn = true;
        }
    }

}
