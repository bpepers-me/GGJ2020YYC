using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteControl : MonoBehaviour
{
    public AudioSource audioSource;

    public void Clicked()
    {
        audioSource.mute = !audioSource.mute;
    }
}
