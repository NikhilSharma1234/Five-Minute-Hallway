using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalEnvManager : MonoBehaviour
{
    public GameObject WorldB;
    public Transform PortalAFrame;
    public Transform PortalBFrame;
    public GameObject PortalB;
    public string LayerToSetBTo = "Portal Enviornment";
    private Vector3 PortalOffset;

    void Awake()
    {
        int LayerPortalEnv = LayerMask.NameToLayer(LayerToSetBTo);
        ChangeLayers(WorldB.transform.GetChild(1), LayerPortalEnv);
        ChangeLayers(WorldB.transform.GetChild(2), LayerPortalEnv);
        PortalOffset = PortalBFrame.position - PortalAFrame.position;
        WorldB.transform.position -= PortalOffset;
        PortalB.SetActive(false);
    }

    
    void ChangeLayers(Transform obj, int newLayer) // Recursively change the layer of all children of the object
    {
        obj.gameObject.layer = newLayer;
        foreach(Transform child in obj)
        {
            ChangeLayers(child, newLayer);
        }
    }
}
