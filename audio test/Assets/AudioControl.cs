using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class AudioControl : MonoBehaviour
{
    //public AudioMixer audioMixer;
    public Slider slider;
    public AudioSource audioSource;
    
    //public Slider pitchSlider;
    //public Slider tempoSlider;

    void Start()
    {
        int halfLength = 40;
        int minValue = -halfLength + 1;
        int maxValue = halfLength - 1;
        int magicNumber = Random.Range(minValue, maxValue);
        slider.minValue = magicNumber - halfLength;
        slider.maxValue = magicNumber + halfLength;
        Debug.Log("Min = " + minValue + ", Max = " + maxValue + ", magic = " + magicNumber);
        Debug.Log("Slider min = " + slider.minValue + ", slider max = " + slider.maxValue);
        slider.onValueChanged.AddListener (delegate {SliderUpdated ();});
    }

    public void SliderUpdated() {
        Debug.Log("Min = " + slider.minValue + ", Max = " + slider.maxValue);
        Debug.Log(slider.value);

        audioSource.pitch = SliderToPitch(slider.value);
        Debug.Log(SliderToPitch(slider.value));
    }

    private float SliderToPitch(float sliderValue) {
        return GetPitch(sliderValue * (3.0f/100.0f));
    }

    private float GetTempo(float tempoValue)
    {
        float tempo;
        if (tempoValue >= 0.0f)
        {
            tempo = tempoValue + 1.0f;
        }
        else
        {
            tempo = 1.0f / (-tempoValue + 1.0f);
        }

        return tempo;
    }

    private float GetPitch(float pitchValue)
    {
        float pitch;
        if (pitchValue >= 0.0f)
        {
            pitch = pitchValue + 1.0f;
        }
        else
        {
            pitch = 1.0f / (-pitchValue + 1.0f);
        }

        return pitch; // /GetTempo()
    }

    /*public void UpdateAudio()
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
    }*/
}
