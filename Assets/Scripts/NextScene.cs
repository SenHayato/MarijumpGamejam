using UnityEngine;
using UnityEngine.SceneManagement;

public class NextSceneLoader : MonoBehaviour
{
    public string NamaScene;
    // This method will load the next scene in the build order
    public void LoadNextScene()
    {
        // Get the current scene's index
        //int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        // Load the next scene in the build order
        SceneManager.LoadScene(NamaScene);
    }
}
