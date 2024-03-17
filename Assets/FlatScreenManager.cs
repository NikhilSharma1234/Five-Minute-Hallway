using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FlatScreenManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Singleton pattern
        if (FindObjectsOfType<FlatScreenManager>().Length > 1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
        
        CheckXRStatus();
    }

    public void CheckXRStatus()
    {
        if (UnityEngine.XR.XRSettings.enabled)
        {
            Debug.Log("XR is active.");
        }
        else
        {
            Debug.Log("XR is not available.");
        }
    }   

    // Update is called once per frame
    void Update()
    {
        
    }
}
