using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioControl : MonoBehaviour
{
    public AudioSource audio1;
    public AudioMixer audioMixer;
    public Slider pitchSlider;
    public Slider tempoSlider;

    public void PitchChanged()
    {
        // TODO: use audio mixer to set the pitch
    }

    public void TempoChanged()
    {
        float tempo;
        if (tempoSlider.value >= 0.0f)
        {
            tempo = tempoSlider.value + 1.0f;
        }
        else
        {
            tempo = 1.0f / (-tempoSlider.value + 1.0f);
        }

        audioMixer.SetFloat("masterTempo", tempo);
        audioMixer.SetFloat("masterPitch", 1.0f / tempo);
    }
}
