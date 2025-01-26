using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2Active : MonoBehaviour
{
    [SerializeField] private PlayerControls control;
    [SerializeField] private float moveSpeed;
    [SerializeField] private float jumpForce;
    //[SerializeField] private AudioSource jumpClip;
    //[SerializeField] private float jumpSpeed;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private bool isGrounded;
    private float horizontalValue;

    Animator animator => GetComponent<Animator>();

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip Lompat;

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
        animator.SetBool("run", Mathf.Abs(horizontalValue) > 0.01f);

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
            audioSource.PlayOneShot(Lompat);
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
            animator.SetTrigger("jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            //jumpSound.Play();
            //jumpClip.PlayOneShot(l);
            audioSource.PlayOneShot(Lompat);
            isGrounded = false;
        }
    }


    void Update()
    {
        Movement();
        JumpMove();
        animator.SetBool("grounded",isGrounded);
    }
    
}
