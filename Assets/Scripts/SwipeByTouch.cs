using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeByTouch : MonoBehaviour
{
    private Vector2 fingerDownPosition;
    private Vector2 fingerUpPosition;

    private bool notSwiped = true;

    private Rigidbody2D rb;
    private readonly float minDistanceForSwipe = 20f;
    private string myName;

    // Update is called once per frame
    private void Start()
    {
        myName = name;
        rb = GetComponent<Rigidbody2D>();
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

            if (hitInformation.collider && hitInformation.collider.name == myName && notSwiped)
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
        if (distance > minDistanceForSwipe)
        {
            // Swipe to the right
            Debug.Log("Swipe to the right");
            notSwiped = false;
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.AddForce(new Vector2(250, 0));
        }   
        if (distance < -minDistanceForSwipe)
        {
            // Swipe to the left
            Debug.Log("Swipe to the left");
            notSwiped = false;
            rb.bodyType = RigidbodyType2D.Dynamic;
            rb.AddForce(new Vector2(-250, 0));

        }
    }

    //private IEnumerator GetSwipedAway(bool right)
    //{ 
    //    int leftOrRight = right == true ? 1 : -1;
    //    int i = 0;
    //    while (i < 3000)
    //    {
    //        transform.position += new Vector3(0.1f * leftOrRight, 0f, 0f);
    //        i++;
    //        yield return new WaitForSeconds(0.1f);
    //    }
    //    yield break;
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Bracket"))
        {
            rb.bodyType = RigidbodyType2D.Static;
            notSwiped = true;
        }
    }
}
