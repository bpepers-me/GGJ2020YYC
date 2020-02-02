using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightControl : MonoBehaviour
{
    public Slider[] sliders;
    public Button[] lamps;
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
                sliderSum++;
            }
        }

        for (int i = 0; i < lamps.Length; i++) {
            if (i < sliderSum) {
                lamps[i].enabled = true;
            } else {
                lamps[i].enabled = false;
            }
        }

    }
}

