using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public Sound[] sounds;
<<<<<<< HEAD
    public bool isMusicEnabled;
    public bool isSoundEnabled;
    private bool isMenuMusic = true;
=======
>>>>>>> parent of cd11cb1a (Uprava web scriptu pre laravel)

    [HideInInspector] public string musidId;


    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
            s.source.playOnAwake = false;
        }

<<<<<<< HEAD
        PlayMusic("menu_music");
        isMenuMusic = true;
    }

    public void ChangeMusic()
    {
        if (isMenuMusic)
        {
            isMenuMusic = false;
            PlayMusic("game_music");
            MuteMusic("menu_music");
        }
        else
        {
            isMenuMusic = true;
            PlayMusic("menu_music");
            MuteMusic("game_music");
        }
=======
        Play("music_1");
>>>>>>> parent of cd11cb1a (Uprava web scriptu pre laravel)
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Sound: " + name + " not found!");
            return;
        }

            if(SoundManager.IsSoundActive())  s.source.Play(); // ak mam zapnute zvuky
    }

<<<<<<< HEAD
    public void PlayMusic(string name)
=======
    public void UpdateMusicVolume(string name) // vyp music -> volume 0 <<>> zap music -> volume 0.1
>>>>>>> parent of cd11cb1a (Uprava web scriptu pre laravel)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Music: " + name + " not found!");
            return;
        }

        if (SoundManager.IsMusicActive()) s.source.volume =s.volume; // ak mam zapnute zvuky
        else s.source.volume = 0f;
    }

    public void MuteMusic(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if (s == null)
        {
            Debug.Log("Music: " + name + " not found!");
            return;
        }

        s.source.volume = 0.0f;

        s.source.Pause();

    }

}
