using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayControl : MonoBehaviour
{
    public AudioSource[] sources;

    public void RestartAudio()
    {
        StopAudio();
        PlayAudio();
    }

    public void StopAudio()
    {
        foreach (var source in sources)
        {
            source.Stop();
        }
    }

    public void PlayAudio()
    {
        foreach (var source in sources)
        {
            source.Play();
        }
    }
}
