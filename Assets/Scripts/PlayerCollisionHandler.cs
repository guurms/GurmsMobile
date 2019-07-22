using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    public static PlayerCollisionHandler Instance;
    public bool playerIsGrounded = false;

    private void Awake()
    {
        Instance = this;
    }

    private void Update() 
    {
        if(transform.parent != null)
        {
            playerIsGrounded = true;
        }
        else
        {
            playerIsGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D col) 
    {
        transform.SetParent(col.transform);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //Might want if statement later if its possible for the player to enter other triggers
        Death();
    }

    public void Death()
    {
        Destroy(gameObject);
        Time.timeScale = 0.4f;
    }
}
