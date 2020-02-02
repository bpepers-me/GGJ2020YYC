using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Audio;

public class VideoControl : MonoBehaviour
{
    public Slider slider;
    private Material videoMaterial;
    public string materialParamName;
    public bool isFixed;
    public Renderer renderer;

    void Start()
    {
        videoMaterial = renderer.material;
        int halfLength = 40;
        int minValue = -halfLength + 1;
        int maxValue = halfLength - 1;
        int magicNumber = Random.Range(minValue, maxValue);
        slider.minValue = magicNumber - halfLength;
        slider.maxValue = magicNumber + halfLength;
        if (!isFixed) {
            slider.value = slider.minValue + halfLength;
            SliderUpdated();
            slider.onValueChanged.AddListener (delegate {SliderUpdated ();});
        } else {
            slider.enabled = false;
        }
    }

    public void SliderUpdated() {
        float sliderValue = Mathf.Round(slider.value / 4.0f) * 4.0f;
        sliderValue = Mathf.Abs(sliderValue);
        sliderValue = sliderValue / 100.0f;

        videoMaterial.SetFloat(materialParamName, sliderValue);
    }
}
