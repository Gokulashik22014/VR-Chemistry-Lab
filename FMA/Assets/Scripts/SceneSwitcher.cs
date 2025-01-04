using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    // Method to switch to a specified scene
    public void SwitchScene(string sceneName)
    {
        // Load the specified scene
        SceneManager.LoadScene(sceneName);
    }

    // Optional: Method to load the next scene in build settings
    public void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        // Check if the next scene index is valid
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
    }
}
