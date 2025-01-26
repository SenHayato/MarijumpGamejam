using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubbleStatus : MonoBehaviour
{
    BubbleBehavior bubbleBehavior;
    [SerializeField] LayerMask playerLayer;
    private void Start() {
        bubbleBehavior = transform.parent.GetComponent<BubbleBehavior>();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // bubbleBehavior.playerHasStand = true;
    }
    void OnTriggerStay2D(Collider2D other)
    {
        // bubbleBehavior.playerHasStandTime += Time.deltaTime;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        // bubbleBehavior.playerHasStand = false;
    }
}
