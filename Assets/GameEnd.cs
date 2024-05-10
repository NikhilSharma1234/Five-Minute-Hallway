using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnd : MonoBehaviour
{
    public Canvas canvas;

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            canvas.gameObject.SetActive(true);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
