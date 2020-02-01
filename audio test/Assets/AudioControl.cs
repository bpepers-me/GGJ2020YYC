using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AudioControl : MonoBehaviour
{
    public AudioSource audio1;
    public Slider pitchSlider;
    public Slider tempoSlider;

    public void PitchChanged()
    {
        // TODO: use audio mixer to set the pitch
    }

    public void TempoChanged()
    {
        audio1.pitch = 1.0f + tempoSlider.value / 100.0f;
        // TODO: also need to adjust pitch down
    }
}
