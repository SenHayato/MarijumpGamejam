using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    [SerializeField] private float healthValue; // Amount of health to add
    [SerializeField] private AudioClip pickupSound; // Sound to play on pickup
    [SerializeField] private GameObject pauseCanvas; // Reference to the Canvas to display

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player2")) // Check if the collider is the player
        {
            // Play the pickup sound
            if (SoundManager.instance != null && pickupSound != null)
            {
                SoundManager.instance.PlaySound(pickupSound);
            }

            // Add health to the player
            Health playerHealth = collision.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.AddHealth(healthValue);
            }

            // Disable the collectible
            gameObject.SetActive(false);

            // Enable the pause canvas
            if (pauseCanvas != null)
            {
                pauseCanvas.SetActive(true);
            }

            // Pause the game
            Time.timeScale = 0f; // Freezes the game
        }
    }
}
