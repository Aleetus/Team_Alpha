using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is created by Cenk Köknar for educational purposes.
/// Please ask for permission before use by sending email to c.koknar@uel.ac.uk
/// </summary>

public class ActiveEventManager : MonoBehaviour
{
    public bool isRepeatable;
    public string activeEventText;
    public string knotName;
    public NarrativeManager narrativeManager;

    //show a button to interact if the player enters the event trigger
    private void OnTriggerEnter(Collider other)
    {
        narrativeManager.highlightedKnot = knotName;
        narrativeManager.inGameUIManager.activeEventButton.SetActive(true);
        narrativeManager.UpdateActiveEventButton(activeEventText);
    }

    //hide the event interact button and destroy if the event is not repeatable
    private void OnTriggerExit(Collider other)
    {
        narrativeManager.highlightedKnot = "nothing to inspect";
        narrativeManager.inGameUIManager.activeEventButton.SetActive(false);

        if (!isRepeatable)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
