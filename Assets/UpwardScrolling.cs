using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpwardScrolling : MonoBehaviour
{
    [SerializeField]
    private float scrollSpeed = 5f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        transform.position += Time.deltaTime * scrollSpeed * Vector3.up;
        //rb.MovePosition(transform.position += Time.deltaTime * scrollSpeed * Vector3.up);
    }
}
