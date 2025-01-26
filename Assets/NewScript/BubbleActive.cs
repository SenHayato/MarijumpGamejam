using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleActive : MonoBehaviour
{
    [SerializeField] Animator animator;
    // Start is called before the first frame update

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player2"));
        {
            Destroy(gameObject, 0.5f);
            animator.SetTrigger("Explode");
        }
    }

    private void OnDestroy()
    {
        Debug.Log("Pecah");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
