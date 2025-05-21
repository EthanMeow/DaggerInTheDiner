using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoaderDelayed : MonoBehaviour
{
    public string sceneName2;// The name of the scene to load
    public float delay = 5f; // Time in seconds before the scene loads

    private void Start()
    {
        Invoke("LoadScene", delay); // Calls the LoadScene function after "delay" seconds
    }

    private void LoadScene()
    {
        SceneManager.LoadScene(sceneName2);
    }
}
