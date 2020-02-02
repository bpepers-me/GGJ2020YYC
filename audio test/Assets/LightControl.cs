using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LightControl : MonoBehaviour
{
    public Slider[] sliders;
    public Button[] lamps;

    private void Start()
    {
        SetLamps();
    }

    public void SetLamps()
    {
        int sliderSum = 0;
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
