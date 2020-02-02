using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinStateChecker : MonoBehaviour
{
    private LightControl[] lights;
    public GameObject WinPanel;

    // Start is called before the first frame update
    void Start()
    {
        lights = FindObjectsOfType<LightControl>();
        WinPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        bool allSuccess = true;
        foreach (LightControl light in lights) {
            if (!light.success) {
                allSuccess = false;
                break;
            }
        }
        if (allSuccess) {
            WinPanel.SetActive(true);
        }
    }
}
