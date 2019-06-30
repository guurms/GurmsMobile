using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenPositionAdjuster : MonoBehaviour
{
    private Vector3 desiredPosition;
    private PlayerCollisionHandler playerCol;
    private Rigidbody2D rb;

    private void Awake() 
    {
        rb = GetComponent<Rigidbody2D>();
        playerCol = GetComponent<PlayerCollisionHandler>();
        desiredPosition = transform.position;
    }

    void Update()
    {
        if(transform.position.y - desiredPosition.y > 0f && !playerCol.playerIsGrounded)
        {
            rb.gravityScale = 0.5f;
        }
        else
        {
            rb.gravityScale = 0;
        }
    }
}
