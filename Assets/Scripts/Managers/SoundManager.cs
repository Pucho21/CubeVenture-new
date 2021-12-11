using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private static readonly string sound = "soundsActive";
    private static readonly string music = "musicActive";
    public static bool IsSoundActive()
    {
        int active = PlayerPrefs.GetInt(sound, 1);
        if (active == 1)
            return true;
        else
            return false;
    }

    public static bool IsMusicActive()
    {
        int active = PlayerPrefs.GetInt(music,1);
        if (active == 1)
            return true;
        else
            return false;
    }

    public static void ToggleSounds()
    {
        if (IsSoundActive())
            PlayerPrefs.SetInt(sound, 0);
        else
            PlayerPrefs.SetInt(sound, 1);
        PlayerPrefs.Save();
    }

    public static void ToggleMusic()
    {
        if (IsMusicActive())
            PlayerPrefs.SetInt(music, 0);
        else
            PlayerPrefs.SetInt(music, 1);
        PlayerPrefs.Save();
    }
}
