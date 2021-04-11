using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Trigger_Load_Scene_Delayed : MonoBehaviour
{
    public float delay = 440;
    public string loadLevel;


    void OnTriggerEnter(Collider other)
    {


        void Start()
        {
            StartCoroutine(LoadLevelAfterDelay(delay));
        }

        IEnumerator LoadLevelAfterDelay(float delay)
        {
            yield return new WaitForSeconds(delay);
            if (other.tag == "Player")
            {
                SceneManager.LoadScene(loadLevel);
            }
        }
    }


}