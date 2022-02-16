using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject menu;
    public GameObject aboutMenu;
    public void PlayGame()
    {
        FlowManager.Instance.ChangeFlows(FlowManager.SceneNames.Game);
        //Debug.Log("play");
    }

    public void ReturnMenu()
    {
        FlowManager.Instance.ChangeFlows(FlowManager.SceneNames.MainMenu);
    }

    public void QuitGame()
    {
        //Debug.Log("QUIT!");
        Application.Quit();
    }

    public void OpenAbout()
    {
        menu.SetActive(false);
        aboutMenu.SetActive(true);
        //Debug.Log("about");
    }

    public void CloseAbout()
    {
        aboutMenu.SetActive(false);
        menu.SetActive(true);
    }
}
