using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// This script is created by Cenk Köknar for educational purposes.
/// Please ask for permission before use by sending email to c.koknar@uel.ac.uk
/// </summary>

public class ReactiveEventManager : MonoBehaviour
{
    public bool isRepeatable;
    public string knotName;
    public NarrativeManager narrativeManager;

    //when player enters the trigger, pass the knot info and run the event automatically
    private void OnTriggerEnter(Collider other)
    {
        narrativeManager.highlightedKnot = knotName;
        narrativeManager.InitiateEvent();
    }

    //destroy the event trigger if it is not repeatable
    private void OnTriggerExit(Collider other)
    {
        if(!isRepeatable)
        {
            GameObject.Destroy(gameObject);
        }
    }
}
