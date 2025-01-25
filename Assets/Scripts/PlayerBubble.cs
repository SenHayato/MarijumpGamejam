
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using UnityEngine;

public class PlayerBubble : MonoBehaviour
{
    // private PlayerInput playerInput => GetComponent<PlayerInput>();
    PlayerControls playerControls;
    [SerializeField] PlayerType playerType;

    [SerializeField] private GameObject bubblePrefab;       // Prefab of the bubble
    [SerializeField] private GameObject spawnPoint;         // GameObject where the bubble will spawn
    [SerializeField] private AudioClip bubbleSound;         // Sound for bubble creation
    [SerializeField] private float bubbleLifetime = 5f;     // Lifetime of the bubble
    public bool bubbleReady;

    void Awake()
    {
        playerControls = FindAnyObjectByType<PlayerControls>();
        
    }
    private void Update()
    {
        // Check if the ENTER key is pressed
        if (playerType == PlayerType.Player_1 && playerControls.GetActionPlayer_1())
        {
            StartCoroutine(SpawnBubble());
        }
    }

    /*private void SpawnBubble()
    {
        // Play the bubble creation sound
        if (bubbleSound != null)
        {
            SoundManager.instance.PlaySound(bubbleSound);
        }

        // Ensure the bubblePrefab and spawnPoint are assigned
        if (spawnPoint != null && bubblePrefab != null)
        {
            // Instantiate the bubble at the spawnPoint's position
            GameObject bubble = Instantiate(bubblePrefab, spawnPoint.transform.position, Quaternion.identity);

            // Ensure the bubble is active in case the prefab is inactive
            bubble.SetActive(true);

            // Initialize the bubble's behavior if it has a BubbleBehavior script
            BubbleBehavior bubbleBehavior = bubble.GetComponent<BubbleBehavior>();
            if (bubbleBehavior != null)
            {
                bubbleBehavior.Initialize(bubbleLifetime);
            }
        }
        else
        {
            //Debug.LogWarning("SpawnPoint or BubblePrefab is not assigned in the PlayerBubble script!");
        }
    }*/

    public IEnumerator SpawnBubble()
    {
        if (bubbleReady)
        {
            Instantiate(bubblePrefab, spawnPoint.transform.position, Quaternion.identity);
            SoundManager.instance.PlaySound(bubbleSound);
            bubbleReady = false;
            yield return new WaitForSeconds(1f);
            bubbleReady = true;
        }
    }
}
