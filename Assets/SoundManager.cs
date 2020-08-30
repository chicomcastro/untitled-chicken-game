using System;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioSource _musicPlayer;
    [SerializeField] private AudioSource _soundPlayer;

    public AudioClip LofiN1;
    public AudioClip LofiN3;
    public AudioClip Funkao;
    public AudioClip ChickenOSClick;
    public AudioClip ChickenOSNotification1;
    public AudioClip ChickenOSNotification2;
    public AudioClip ChickenOSStartup;
    public AudioClip Clucking;
    public AudioClip Clucking_2;
    public AudioClip Drinking;
    public AudioClip Eating;
    public AudioClip Hamster_wheel;

    private void Start()
    {
        Instance = this;
        DontDestroyOnLoad(this);
    }

    public void SetSong(AudioClip song)
    {
        _musicPlayer.Stop();
        _musicPlayer.clip = song;
        _musicPlayer.Play();
    }
    
    public void PlaySound(AudioClip song, bool loop)
    {
        _soundPlayer.Stop();
        _soundPlayer.clip = song;
        _soundPlayer.loop = loop;
        _soundPlayer.Play();
    }

    public void StopSound()
    {
        _soundPlayer.Stop();
    }
}
