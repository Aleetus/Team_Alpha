using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is created by Cenk Köknar for educational purposes.
/// Please ask for permission before use by sending email to c.koknar@uel.ac.uk
/// </summary>

public class MainMenuManager : MonoBehaviour
{
    public GameObject hudPanel;
    public GameObject mainMenuPanel;
    public GameObject creditsPanel;
    public GameObject inGameMenuPanel;
    public GameObject dialoguePanel;


    public void PlayGame()
    {
        CloseAllPanels();
        hudPanel.SetActive(true);
    }

    public void OpenCredits()
    {
        CloseAllPanels();
        creditsPanel.SetActive(true);
    }

    public void GoBacktoMainMenu()
    {
        CloseAllPanels();
        mainMenuPanel.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    void CloseAllPanels()
    {
        hudPanel.SetActive(false);
        mainMenuPanel.SetActive(false);
        creditsPanel.SetActive(false);
        inGameMenuPanel.SetActive(false);
        dialoguePanel.SetActive(false);
    }
}
