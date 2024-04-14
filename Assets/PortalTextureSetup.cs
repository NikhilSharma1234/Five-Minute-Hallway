using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTextureSetup : MonoBehaviour
{
    public Camera cameraA;
    public Camera cameraB;
    public Material cameraMatB;
    // Start is called before the first frame update
    void Start()
    {
        if(cameraB.targetTexture != null)
        {
            cameraB.targetTexture.Release();
        }
        cameraB.targetTexture = new RenderTexture(cameraA.pixelWidth, cameraA.pixelHeight, 24);
        cameraB.targetTexture.antiAliasing = 1;
        cameraMatB.mainTexture = cameraB.targetTexture;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
