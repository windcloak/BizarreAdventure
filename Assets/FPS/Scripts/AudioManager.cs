using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public AudioMixer[] audioMixers;

    [Tooltip("Sounds used in game")]
    public Sound[] sounds;

    public AudioMixerGroup[] FindMatchingGroups(string subPath)
    {
        for (int i = 0; i < audioMixers.Length; i++)
        {
            AudioMixerGroup[] results = audioMixers[i].FindMatchingGroups(subPath);
            if (results != null && results.Length != 0)
            {
                return results;
            }
        }

        return null;
    }

    public void SetFloat(string name, float value)
    {
        for (int i = 0; i < audioMixers.Length; i++)
        {
            if (audioMixers[i] != null)
            {
                audioMixers[i].SetFloat(name, value);
            }
        }
    }

    public void GetFloat(string name, out float value)
    {
        value = 0f;
        for (int i = 0; i < audioMixers.Length; i++)
        {
            if (audioMixers[i] != null)
            {
                audioMixers[i].GetFloat(name, out value);
                break;
            }
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        // check if sound exists
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.Play();
    }
}
