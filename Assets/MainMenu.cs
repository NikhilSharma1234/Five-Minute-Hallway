using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    public GameObject mainMenu;
    private bool gameStarted = false;
    public GameObject MainMenuBoundary;
    

    public void Update(){
        if(gameStarted){
            Vector3 mainMenuScale = mainMenu.transform.localScale;
            Vector3 newScale = new Vector3(mainMenuScale.x * 0.95f, mainMenuScale.y * 0.95f, mainMenuScale.z * 0.95f);
            if(newScale.x < 0.0000001f){
                newScale = new Vector3(0.1f, 0.1f, 0.1f);
                mainMenu.SetActive(false);
            }
            mainMenu.transform.localScale = newScale;
            if(MainMenuBoundary != null) Destroy(MainMenuBoundary);
        }
    }

    public void StartGame()
    {
        gameStarted = true;
    }

    IEnumerator DisableMainMenu()
    {
        yield return new WaitForSeconds(5);
        mainMenu.SetActive(false);
        gameStarted = false;
    }
}
