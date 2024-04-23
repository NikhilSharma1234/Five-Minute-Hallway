using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    public Transform player;
    public GameObject regularWorld;
    public GameObject portalWorld;
    public MeshRenderer portalSurface;
    public GameObject otherPortal;
    public GameObject OcculusionWorld;
    public GameObject OcculusionPortalWorld;
    public bool playerOverlapping = false;

    void Start(){
        OcculusionWorld.SetActive(true);
        OcculusionPortalWorld.SetActive(false);
    }
    void Update()
    {
        if (playerOverlapping)
        {
            Vector3 portalToPlayer = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            if(dotProduct < 0f)
            {
                portalWorld.layer = 0;
                ChangeLayers(portalWorld.transform, 0);
                
                portalSurface.enabled = false;
                regularWorld.layer = 6;
                ChangeLayers(regularWorld.transform, 6);
                otherPortal.SetActive(true);
                otherPortal.GetComponent<MeshRenderer>().enabled = true;
                OcculusionWorld.SetActive(false);
                OcculusionPortalWorld.SetActive(true);
                ChangeLayers(OcculusionPortalWorld.transform, 6);
                playerOverlapping = false;
                this.gameObject.SetActive(false);
            }
        }
    }

    void ChangeLayers(Transform obj, int newLayer) // Recursively change the layer of all children of the object
    {
        obj.gameObject.layer = newLayer;
        foreach(Transform child in obj)
        {
            ChangeLayers(child, newLayer);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Player entered " + this.gameObject.name + ".");
        if(other.tag == "Player")
        {
            playerOverlapping = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        //Debug.Log("Player exited the portal.");
        if(other.tag == "Player")
        {
            playerOverlapping = false;
        }
    }
}
