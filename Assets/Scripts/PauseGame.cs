using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public GameObject pauseCanvas; // Drag your Canvas here in the Inspector
    private bool isPaused = false;

    void Update()
    {
        // Example: Trigger pause with a condition or a key press
        if (Input.GetKeyDown(KeyCode.P) || SomeConditionMet())
        {
            TogglePause();
        }
    }

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            // Pause the game
            Time.timeScale = 0f; // Stops all in-game time
            pauseCanvas.SetActive(true); // Show the canvas
        }
        else
        {
            // Resume the game
            Time.timeScale = 1f; // Restores in-game time
            pauseCanvas.SetActive(false); // Hide the canvas
        }
    }

    // Example of a condition you can use
    private bool SomeConditionMet()
    {
        // Add your custom logic here
        // e.g., return PlayerHealth <= 0;
        return false; // Default for now
    }
}
