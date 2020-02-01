using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioControl : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider pitchSlider;
    public Slider tempoSlider;

    private float GetTempo()
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

        return tempo;
    }

    private float GetPitch()
    {
        float pitch;
        if (pitchSlider.value >= 0.0f)
        {
            pitch = pitchSlider.value + 1.0f;
        }
        else
        {
            pitch = 1.0f / (-pitchSlider.value + 1.0f);
        }

        return pitch / GetTempo();
    }

    public void UpdateAudio()
    {
        audioMixer.SetFloat("masterTempo", GetTempo());
        audioMixer.SetFloat("masterPitch", GetPitch());
    }

    public void PitchChanged()
    {
        UpdateAudio();
    }

    public void TempoChanged()
    {
        UpdateAudio();
    }
}
