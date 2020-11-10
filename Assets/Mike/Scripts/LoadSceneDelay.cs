using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneDelay : MonoBehaviour
{
    public float delay = 440;
    public string loadLevel;


    void Start()
    {
        StartCoroutine(LoadLevelAfterDelay(delay));
    }

    IEnumerator LoadLevelAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadScene(loadLevel);
    }
}