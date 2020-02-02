using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightControl : MonoBehaviour
{
    public Slider[] sliders;
    public Image lamp;
    public Text textBlock;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        float sliderSum = 0;
        foreach(Slider i in sliders)
        {
            if(Mathf.Abs(i.value)<=4)
            {
            sliderSum ++;
            }
        }

        if (sliderSum>=sliders.Length)
        {
            lamp.color = Color.green;
        }

    }
}

