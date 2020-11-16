using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlanetInteract : MonoBehaviour
{
    public string loadScene;

    // Detect if something enters the Trigger
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            print ("collider detected");
            
            if (Input.GetKeyDown(KeyCode.Space))
            {
                print ("space is being pressed");
                SceneManager.LoadScene(loadScene);
            }     
        }
    }
}
