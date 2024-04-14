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
    public bool playerOverlapping = false;

    void Update()
    {
        if (playerOverlapping)
        {
            Vector3 portalToPlayer = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            if(dotProduct < 0f)
            {
                portalWorld.layer = 0;
                foreach(Transform child in portalWorld.transform)
                {
                    child.gameObject.layer = 0;
                }
                portalSurface.enabled = false;
                regularWorld.layer = 6;
                foreach(Transform child in regularWorld.transform)
                {
                    child.gameObject.layer = 6;
                }
                otherPortal.SetActive(true);
                otherPortal.GetComponent<MeshRenderer>().enabled = true;
                playerOverlapping = false;
                this.gameObject.SetActive(false);
            }
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
