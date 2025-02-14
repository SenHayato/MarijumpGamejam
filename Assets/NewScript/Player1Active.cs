using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class Player1Active : MonoBehaviour
{
    [SerializeField] private PlayerControls control;
    [SerializeField] private float moveSpeed;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject bubbleObj;
    [SerializeField] private GameObject Player1;
    // [SerializeField] private GameObject SoundBlow;
    private float horizontalValue;
    [SerializeField] private float bubbleDuration;
    private Vector3 velocity;
    [SerializeField] private bool bubbleReady;

    Animator animator => GetComponent<Animator>();

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip Blow;


    // Start is called before the first frame update
    private void Awake()
    {
        control = FindAnyObjectByType<PlayerControls>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        bubbleReady = true;
        // Player1 = GameObject.FindGameObjectWithTag("Player1");
    }
    void Start()
    {
        
    }

    void Movement()
    {
        velocity = Vector3.zero;
        horizontalValue = control.GetAxis_Player_1();
        animator.SetBool("run", Mathf.Abs(horizontalValue) > 0.01f);
        if (horizontalValue > 0.01f)
        {
            spriteRenderer.flipX = false;
            velocity.x = moveSpeed * Time.deltaTime;
        } else if (horizontalValue < -0.01f)
        {
            spriteRenderer.flipX = true;
            velocity.x = -moveSpeed * Time.deltaTime;
        }
        transform.Translate(velocity);
    }
    // Update is called once per frame
    void Update()
    {
        Movement();
        StartCoroutine(BlowBubble());
    }
    IEnumerator BlowBubble()
    {
        if (bubbleReady)
        {
            if (control.GetActionPlayer_1())
            {
                Instantiate(bubbleObj, Player1.transform.position, Quaternion.identity);
                audioSource.PlayOneShot(Blow);
                bubbleReady = false;
                yield return new WaitForSeconds(bubbleDuration);
                bubbleReady = true;
            }
        }
        
    }


}
