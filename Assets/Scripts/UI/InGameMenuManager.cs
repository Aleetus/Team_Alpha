using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script is created by Cenk Köknar for educational purposes.
/// Please ask for permission before use by sending email to c.koknar@uel.ac.uk
/// </summary>

public class InGameMenuManager : MonoBehaviour
{
    public KeyCode menuKey = KeyCode.Escape;

    public GameObject inGameMenuPanel;
    public GameObject dialoguePanel;
    public GameObject hudPanel;
    //textfield to show in the game
    public Text textField;
    //choicebuttons
    public GameObject[] choiceButtons;
    public GameObject activeEventButton;

    private void Update()
    {
        if(Input.GetKeyDown(menuKey))
        {
            ShowInGameMenu();
        }
    }

    //switches between gameplay and dialogue, disable player movement here if desired
    public void GameplayDialogueToggle()
    {
        hudPanel.SetActive(!hudPanel.activeSelf);
        dialoguePanel.SetActive(!dialoguePanel.activeSelf);
    }

    //clear the choice buttons 
    public void ClearChoiceButtons()
    {
        foreach (var item in choiceButtons)
        {
            item.SetActive(false);
        }
    }

    //show relevant buttons based on choice count
    public void ShowChoiceButtons(int choiceCount)
    {
        if (choiceCount == 0)
        {
            choiceButtons[0].SetActive(true);//continue button
        }
        else
        {
            for (int i = 0; i < choiceCount; i++)
            {
                choiceButtons[i + 1].SetActive(true);
            }
        }
    }

    public void ShowInGameMenu()
    {
        inGameMenuPanel.SetActive(true);
    }

    public void HideInGameMenu()
    {
        inGameMenuPanel.SetActive(false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}
