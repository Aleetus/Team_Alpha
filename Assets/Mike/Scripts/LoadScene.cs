using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string sceneToLoad;
    public GameObject canvas;

    // Start is called before the first frame update
    public void LoadLevel()
    {
        SceneManager.LoadScene(sceneToLoad);
        canvas.gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
