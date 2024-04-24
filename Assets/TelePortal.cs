using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelePortal : MonoBehaviour
{
    public Transform player;
    public Transform entrance;
    public Transform exit;
    private Vector3 positionOffset;
    private Vector3 rotationOffset;
    private Vector3 offsetFromEntrance;
    private bool TeleportUsed = false;
    private bool computeOffsets = true;

    void Update()
    {
        computeOffsetsOnce();
        offsetFromEntrance = player.position - entrance.position;
        offsetFromEntrance.Set(offsetFromEntrance.x, 0, offsetFromEntrance.z);
        if (Vector3.Distance(player.position, entrance.position) < 10.0f && !TeleportUsed)
        {
            commenceTeleport();
        }

    }

    void computeOffsetsOnce()
    {
        if (computeOffsets)
        {
            positionOffset = exit.position - entrance.position;
            rotationOffset = exit.rotation.eulerAngles - entrance.rotation.eulerAngles;
            //rotationOffset = rotationOffset;
            computeOffsets = false;
        }
    }

    void commenceTeleport()
    {
        Debug.Log("Portal offset: " + positionOffset);
        Debug.Log("Portal rotation: " + rotationOffset);
        //Debug.Log("Player offset: " + offsetFromEntrance);
        TeleportUsed = true;
        player.position += positionOffset;

        //Quaternion rotationOffsetQuat = Quaternion.Euler(rotationOffset);
        // Rotate offsetFromEntrance by rotationOffset
        //Vector3 rotatedOffset = rotationOffsetQuat * offsetFromEntrance;
        //player.position += rotatedOffset;
        //player.rotation = Quaternion.Euler(player.rotation.eulerAngles + rotationOffset);

        // Rotate the player by rotateOffset
        player.rotation = Quaternion.Euler(player.rotation.eulerAngles + rotationOffset);
        Debug.Log("Player rotated to: " + player.rotation.eulerAngles);
    }
}
