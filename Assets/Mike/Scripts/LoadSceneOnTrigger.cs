using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadSceneOnTrigger : MonoBehaviour
{

    public string loadScene;

    // Detect if something enters the Trigger
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(loadScene);
        }
    }
}
