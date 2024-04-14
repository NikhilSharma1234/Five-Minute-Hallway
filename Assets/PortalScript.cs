using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalScript : MonoBehaviour
{
    public Transform m_otherPortal;
    public Camera m_otherCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 userOffsetFromPortal = Camera.main.transform.position - transform.position;
        m_otherCamera.transform.position = m_otherPortal.transform.position + userOffsetFromPortal;
        m_otherCamera.transform.rotation = m_otherPortal.rotation * Quaternion.Inverse(transform.rotation) * Camera.main.transform.rotation;
    }
}
