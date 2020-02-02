using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteControl : MonoBehaviour
{
    public AudioSource audioSource;
    public Image offImage;

    public void Clicked()
    {
        audioSource.mute = !audioSource.mute;
        offImage.gameObject.SetActive(audioSource.mute);
    }
}
