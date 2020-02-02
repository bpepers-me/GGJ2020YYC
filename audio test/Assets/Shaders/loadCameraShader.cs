using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class loadCameraShader : MonoBehaviour
{

    [SerializeField]
    private Vector2 cellSize = new Vector2(4, 4);

    // Defined statically but should be changed to [Serialize Field]
    [SerializeField]
    private Shader shader;
    private Material material;

    // When object loads (once), calls Awake()
    private void Awake()
    {
        // Shader.Find("Hidden/Pixelated")
        material = new Material(shader);
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        // These should be exposed from the shader itself
        material.SetFloat("_ScreenWidth", Screen.width);
        material.SetFloat("_ScreenHeight", Screen.height);
        material.SetFloat("_CellSizeX", cellSize.x);
        material.SetFloat("_CellSizeY", cellSize.y);
        Graphics.Blit(source, destination, material);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
