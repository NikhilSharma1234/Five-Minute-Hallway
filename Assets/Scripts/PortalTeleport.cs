using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalTeleport : MonoBehaviour
{
    public Transform player;
    public GameObject WorldA;
    public GameObject WorldAOcclusion;
    public GameObject WorldB;
    public GameObject WorldBOcclusion;
    public MeshRenderer portalSurface;
    public GameObject OtherWorldPortal;
    public bool playerOverlapping = false;

    void Start(){
        WorldAOcclusion.SetActive(true);
        WorldBOcclusion.SetActive(false);
    }
    void LateUpdate()
    {
        if (playerOverlapping)
        {
            Vector3 portalToPlayer = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            if(dotProduct < 0f)
            {
                
                portalSurface.GetComponent<MeshRenderer>().enabled = false;
                //WorldB.layer = 0;
                ChangeLayers(WorldB.transform, 0);
                //WorldA.layer = 6;
                ChangeLayers(WorldA.transform, 6);
                OtherWorldPortal.SetActive(true);
                OtherWorldPortal.GetComponent<MeshRenderer>().enabled = true;
                portalSurface.enabled = false;
                WorldAOcclusion.SetActive(false);
                WorldBOcclusion.SetActive(true);
                ChangeLayers(WorldBOcclusion.transform, 8);
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
