using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[RequireComponent(typeof(Camera))]
public class CameraMatchCanvasScaling : MonoBehaviour
{

    [Range(0.1f,1.0f)] public float objectScreenRatio = 1.0f;

    private float objectFrameWidth = 16f;

    Camera _camera;
    void Start()
    {
        _camera = GetComponent<Camera>();
    }

    // Adjust the camera's height so the desired scene width fits in view
    // even if the screen/window size changes dynamically.
    void Update()
    {

        float unitsPerPixel = objectFrameWidth / (Screen.width * objectScreenRatio);
        float desiredHalfHeight = 0.5f * unitsPerPixel * Screen.height;
        _camera.orthographicSize = desiredHalfHeight;

    }

}
