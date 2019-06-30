using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeByTouch : MonoBehaviour
{
    private Vector2 fingerDownPosition;
    private Vector2 fingerUpPosition;

    [SerializeField]
    private float minDistanceForSwipe = 20f;

    // Update is called once per frame
    void Update()
    {

        foreach (Touch touch in Input.touches)
        { 
            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            touchPos.z = 0f;

            //Check if its touching the object 


            //Check what phase the touch is in
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    Debug.Log("touching has begun");
                    fingerUpPosition = touch.position;
                    fingerDownPosition = touch.position;
                    break;
                case TouchPhase.Moved:
                    Debug.Log("its moving omg");
                    fingerDownPosition = touch.position;
                    //transform.position = touchPosition;
                    break;
                case TouchPhase.Ended:
                    fingerDownPosition = touch.position;
                    Debug.Log("yay its done! good job");
                    break;
                default:
                    break;
            }
        }
        
    }
}
