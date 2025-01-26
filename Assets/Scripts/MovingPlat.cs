using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlat : MonoBehaviour
{
    [SerializeField] private bool isRight = true;  
    [SerializeField] private float speed = 2f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Border"))
        {
            if (isRight)
            {
                isRight = false;
            } else
            {
                isRight = true;
            }
        }
    }

    private void Move()
    {
        
        if (isRight)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
        }
    }
    void Update()
    {
        Move();
    }
}
