using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PostProcessing : MonoBehaviour
{
    public float intensity;

    [SerializeField]
    private Material PPMaterial;
    [SerializeField]
    private Shader PPShader;

    private Camera cam;

    void Awake()
    {
        //  PPMaterial = new Material(PPShader);
    }

    private void Start()
    {
        /*cam = GetComponent<Camera>();
        cam.depthTextureMode = cam.depthTextureMode | DepthTextureMode.DepthNormals;*/
    }

    void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        /*if(intensity == 0)
            Graphics.Blit(source, destination);

    */
        // PPMaterial.SetFloat("_bwBlend", intensity);

        Graphics.Blit(source, destination, PPMaterial);
    }

}
