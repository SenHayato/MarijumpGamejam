using UnityEngine;

public class BubbleBehavior : MonoBehaviour
{
    private float lifetime;
    private bool isPlayerStanding;
    private float isPlayerStandingTime;
    public bool playerHasStand;
    public float playerHasStandTime;
    private bool bubbleIsPressed;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private Collider2D playerStandingArea;
    [SerializeField] private float riseSpeed = 2f; // Speed at which the bubble rises
    [SerializeField] private float descendSpeed = 1f; // Speed at which the bubble descends when the player is inside

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Initialize(float bubbleLifetime)
    {
        lifetime = bubbleLifetime;
        Destroy(gameObject, lifetime); // Automatically destroy the bubble after its lifetime
    }

    private void Update()
    {
        // If the player is inside, descend; otherwise, rise
        if (isPlayerStanding)
        {
            rb.velocity = new Vector2(0, -descendSpeed);
        }
        else
        {
            rb.velocity = new Vector2(0, riseSpeed);
        }
        if (playerHasStandTime > 0.15f && isPlayerStandingTime > 0.15f)
        {
            bubbleIsPressed = true;
        }
        if (bubbleIsPressed && !isPlayerStanding)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the player enters the bubble
        if (collision.CompareTag("Player"))
        {
            isPlayerStanding = true;
            // Destroy(gameObject, 1f); // Automatically destroy the bubble after its lifetime
        }
    }
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isPlayerStandingTime += Time.deltaTime;
            // Destroy(gameObject, 1f); // Automatically destroy the bubble after its lifetime
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Check if the player exits the bubble
        if (collision.CompareTag("Player"))
        {
            isPlayerStanding = false;
        }
    }
}
