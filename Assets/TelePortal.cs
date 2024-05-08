using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

public class TelePortal : MonoBehaviour
{
    public Transform player;
    public Transform exit;
    private Vector3 positionOffset;
    private Vector3 rotationOffset;
    private Vector3 offsetFromEntrance;
    private bool playerIsOverlapping = false;
    private bool playerTeleported = false;
    private Vector3 previousPosition;
    public int portalUses = 100;

    void FixedUpdate()
    {
        if(playerIsOverlapping)
        {
            Vector3 portalToPlayer = player.position - transform.position;
            float dotProduct = Vector3.Dot(transform.up, portalToPlayer);

            if(dotProduct < 0f && portalUses > 0)
            {
                //Debug.Log("Position: " + player.position);
                // Disable continuous move provider
                //continuousMoveProvider.enabled = false;
                playerTeleported = true;
                //Debug.Log("Teleporting player...");
                float rotationDiff = -UnityEngine.Quaternion.Angle(transform.rotation, exit.rotation);
                rotationDiff += 180;
                player.Rotate(Vector3.up, rotationDiff);

                Vector3 positionOffset = UnityEngine.Quaternion.Euler(0f, rotationDiff, 0f) * portalToPlayer;
                player.position = exit.position + positionOffset;
                //Debug.Log("teleported player to " + player.position);
                playerIsOverlapping = false;
                portalUses--;
                //continuousMoveProvider.enabled = true;
            }
            


        }
        if(DistanceBetween(player.position, previousPosition) > 1.0f)
        {
            //Debug.Log("Player moved."); 
            //Debug.Log("player position: " + player.position);
        }
        previousPosition = player.position;
    }

    // void OnDrawGizmos()
    // {
    //     Gizmos.color = Color.red;
    //     Gizmos.DrawWireCube(entrance.position, new Vector3(10, 10, 10));
    //     Gizmos.color = Color.green;
    //     Gizmos.DrawWireCube(exit.position, new Vector3(10, 10, 10));
    // }

    float DistanceBetween(Vector3 a, Vector3 b)
    {
        return Vector3.Distance(a, b);
    }

    void OnTriggerEnter(Collider other)
    {
        //Debug.Log("Player entered " + this.gameObject.name + ".");
        if (other.tag == "Player")
        {
            playerIsOverlapping = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        //Debug.Log("Player exited the portal.");
        if (other.tag == "Player")
        {
            playerIsOverlapping = false;
        }
    }
}
