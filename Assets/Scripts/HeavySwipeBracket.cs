using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavySwipeBracket : MonoBehaviour
{
    private Vector2 fingerDownPosition;
    private Vector2 fingerUpPosition;

    private int force = 250;
    private int drag = 10;

    private string left = "Left";
    private string right = "Right";
    private string center = "Middle";

    private Rigidbody2D rb;
    private readonly float minDistanceForSwipe = 20f;

    // Update is called once per frame
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = drag;
    }
    void Update()
    {

        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.touches[i];

            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            touchPos.z = 0f;

            //Check if its touching the object 
            RaycastHit2D hitInformation = Physics2D.Raycast(touchPos, Camera.main.transform.forward);

            if (hitInformation.collider && hitInformation.collider.name == name)
            {
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        fingerUpPosition = touch.position;
                        fingerDownPosition = touch.position;
                        break;
                    case TouchPhase.Moved:
                        fingerDownPosition = touch.position;
                        checkForSwipe();
                        break;
                    case TouchPhase.Ended:
                        fingerDownPosition = touch.position;
                        checkForSwipe();
                        break;
                    default:
                        break;
                }
            }
        }

    }

    void checkForSwipe()
    {
        var distance = fingerDownPosition.x - fingerUpPosition.x;
        //Swipe right
        if (distance > minDistanceForSwipe)
        {
            if (tag == right || tag == center)
            {
                Debug.Log(distance);
                rb.bodyType = RigidbodyType2D.Dynamic;
                rb.AddForce(new Vector2(force, 0));
            }
        }
        //Swipe left
        if (distance < -minDistanceForSwipe)
        {
            if (tag == left || tag == center)
            {
                Debug.Log(distance);
                rb.bodyType = RigidbodyType2D.Dynamic;
                rb.AddForce(new Vector2(-force, 0));
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Bracket"))
        {
            rb.bodyType = RigidbodyType2D.Static;
        }
    }

    public void Reset()
    {
        fingerUpPosition = new Vector2(0f, 0f);
        fingerDownPosition = new Vector2(0f, 0f);
    }
}
