using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    public bool playerIsGrounded = false;

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
}
