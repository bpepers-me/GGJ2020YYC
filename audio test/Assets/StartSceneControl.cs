﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.SceneManagement;

public class StartSceneControl : MonoBehaviour
{
    public GameObject creditButton;
        
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartButtonClick()
    {
        SceneManager.LoadScene("Scenes/Level 1", LoadSceneMode.Single);
    }

    public void Creditclick()
    {
        creditButton.SetActive(false);
    }

    public void CreditButtonClick()
    {
        creditButton.SetActive(true);
    }

}
