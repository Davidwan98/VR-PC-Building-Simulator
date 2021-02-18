using UnityEngine.Audio;
using UnityEngine;
using System;

public class scr_AudioManager : MonoBehaviour
{
    public scr_sound[] sounds;
    void Awake()
    {
        foreach (scr_sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }
    public void Play (string name)
    {
        scr_sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
    }
}
