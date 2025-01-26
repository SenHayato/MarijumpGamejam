using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Active : MonoBehaviour
{
    [SerializeField] private PlayerControls control;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    //[SerializeField] private float jumpSpeed;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private bool isGrounded;
    private float horizontalValue;

    private Rigidbody2D rb;

    private void Awake()
    {
        control = FindAnyObjectByType<PlayerControls>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Movement()
    {
        horizontalValue = control.GetAxis_Player_2();
        if (horizontalValue < -0.01f)
        {
            spriteRenderer.flipX = true;
        } else if (horizontalValue > 0.01f)
        {
            spriteRenderer.flipX = false;
        }
        Vector3 move = new Vector3(horizontalValue * moveSpeed * Time.deltaTime, 0, 0);
        transform.Translate(move);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Bubble"))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        } else
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        isGrounded = false;
    }

    void JumpMove()
    {
        if (isGrounded && control.GetJumpPlayer_2())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }
    }


    void Update()
    {
        Movement();
        JumpMove();
    }
}
