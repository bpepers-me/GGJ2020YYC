using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderSetUp : MonoBehaviour
{


    public Slider videoSlider;
    // Start is called before the first frame update
    void Start()
    {
       
        
    }

    void OnAwake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float GetSliderValue()
        {
            return videoSlider.value;
        }
}
