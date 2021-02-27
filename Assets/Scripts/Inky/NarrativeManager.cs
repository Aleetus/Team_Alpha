using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This script is created by Cenk Köknar for educational purposes.
/// Please ask for permission before use by sending email to c.koknar@uel.ac.uk
/// </summary>

public class NarrativeManager : MonoBehaviour
{
    public InGameMenuManager inGameUIManager;

    //ink json file reference
    public TextAsset inkJSON;

    //typer speed
    public float typingAnimationLetterDelay = 0.01f;

    public GameStates currentState = GameStates.Playing;
    public string highlightedKnot;

    private Story story;

    // Start is called before the first frame update
    void Start()
    {
        story = new Story(inkJSON.text);
    }

    //initiate
    public void InitiateEvent()
    {
        inGameUIManager.activeEventButton.SetActive(false);
        inGameUIManager.GameplayDialogueToggle();
        JumptoKnot(highlightedKnot);
        NextLineInDialogue();
    }

    public void JumptoKnot(string knotName)//for in-game events
    {
        story.ChoosePathString(knotName);
    }

    //choice buttons use this
    public void NextLineInDialogue()
    {
        if (story.canContinue)
        {
            StoryContinue();
        }
        else
        {
            inGameUIManager.GameplayDialogueToggle();
        }
    }
    public void MakeChoice(int index)
    {
        story.ChooseChoiceIndex(index);
    }

    void StoryContinue()
    {
        StartCoroutine(TypeSentence());
    }
    IEnumerator TypeSentence()
    {
        inGameUIManager.ClearChoiceButtons();

        inGameUIManager.textField.text = "";//reset the text field
        string tempText = story.Continue();//get text from ink

        foreach (char letter in tempText.ToCharArray())//show the text letter by letter
        {
            inGameUIManager.textField.text += letter;
            yield return new WaitForSeconds(typingAnimationLetterDelay); //set delay to 0 to show the text directly
        }

        inGameUIManager.ShowChoiceButtons(story.currentChoices.Count);

        //update choice button text if there is any
        if (story.currentChoices.Count != 0)
        {
            for (int i = 0; i < story.currentChoices.Count; i++)
            {
                inGameUIManager.choiceButtons[i + 1].transform.GetChild(0).gameObject.GetComponent<Text>().text = story.currentChoices[i].text;
            }
        }
    }

    public void UpdateActiveEventButton(string tempText)
    {
        inGameUIManager.activeEventButton.transform.GetChild(0).gameObject.GetComponent<Text>().text = tempText;
    }
}

public enum GameStates
{
    Playing = 0,
    Dialogue = 1,
    Menu = 2,
}