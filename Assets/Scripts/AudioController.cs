using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : Singleton<AudioController>
{
    [Header("Main Settings: ")]
    [Range(0, 1)]
    public float musicVolume;
    [Range(0, 1)]
    public float sfxVolume;

    public AudioSource musicAus;
    public AudioSource sfxAus;

    [Header("Game Sounds and Musics")]
    public AudioClip shoot;
    public AudioClip win;
    public AudioClip lose;
    public AudioClip[] backgroundSound;

    public override void Start()
    {
        PlayMusic(backgroundSound);
    }

    public void PlaySound(AudioClip sound, AudioSource aus = null)
    {
        if (!aus)
        {
            aus = sfxAus;
        }

        if (aus)
        {
            aus.PlayOneShot(sound, sfxVolume);
        }
    }

    public void PlayerSound(AudioClip[] sounds, AudioSource aus = null)
    {
        if (!aus)
        {
            aus = sfxAus;
        }

        if (aus)
        {
            int randInx = Random.Range(0, sounds.Length);

            if (sounds[randInx] != null)
            {
                aus.PlayOneShot(sounds[randInx], sfxVolume);
            }
        }
    }

    public void PlayMusic(AudioClip music, bool loop = true)
    {
        if (musicAus)
        {
            musicAus.clip = music;
            musicAus.loop = loop;
            musicAus.volume = musicVolume;
            musicAus.Play();
        }
    }

    public void PlayMusic(AudioClip[] music, bool loop = true)
    {
        if (musicAus)
        {
            int randInx = Random.Range(0, music.Length);

            if (music[randInx] != null)
            {
                musicAus.clip = music[randInx];
                musicAus.loop = loop;
                musicAus.volume = musicVolume;
                musicAus.Play();
            }
        }
    }
}
