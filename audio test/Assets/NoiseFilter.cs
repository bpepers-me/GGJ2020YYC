using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoiseFilter : MonoBehaviour
{
    [Range(-1f, 1f)]
    public float offset;

    public Slider slider;
    public float station;
    public float magnitude;

    System.Random rand = new System.Random();

    public void Start()
    {
        station = ((float)rand.NextDouble() - .5f) * 200.0f;
    }

    public void SetValue()
    {
        magnitude = slider.value;
    }

    void OnAudioFilterRead(float[] data, int channels)
    {
        for (int i = 0; i < data.Length; i++)
        {
            data[i] = data[i] + (float)(rand.NextDouble() * 2.0 - 1.0 + offset) * (magnitude - station) / 100.0f;
        }
    }
}
