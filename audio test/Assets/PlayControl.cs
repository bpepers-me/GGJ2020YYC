using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayControl : MonoBehaviour
{
    public AudioSource source1;
    public AudioSource source2;
    public AudioSource source3;

    public void RestartAudio()
    {
        StopAudio();
        PlayAudio();
    }

    public void StopAudio()
    {
        source1.Stop();
        source2.Stop();
        source3.Stop();
    }

    public void PlayAudio()
    {
        source1.Play();
        source2.Play();
        source3.Play();
    }
}
