using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class HidePlane : MonoBehaviour
{
    public Transform player;
    public GameObject PortalPlaneA;
    public GameObject PortalPlaneB;
    public bool playerBehingPlane = false;

    void Update()
    {
        if(playerBehingPlane){
            if(PortalPlaneA.activeSelf){
                PortalPlaneB.SetActive(false);
            }
        }
        else {
            //PortalPlaneB.SetActive(true);
        }
    }

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("Player entered " + this.gameObject.name + ".");
        if(other.tag == "Player")
        {
            playerBehingPlane = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("Player exited the portal.");
        if(other.tag == "Player")
        {
            playerBehingPlane = false;
        }
    }
}
