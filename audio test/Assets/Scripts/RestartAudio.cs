using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartAudio : MonoBehaviour
{
    public AudioSource[] audioSources;

    public void RestartAllAudio() {
        foreach (AudioSource audioSource in audioSources) {
            audioSource.Stop();
            audioSource.Play();
        }
    }
}
