//using System;
//using UnityEngine;

//public class SwipeDetector : MonoBehaviour
//{
//    private Vector2[] fingerDownPosition = new Vector2[10];
//    private Vector2[] fingerUpPosition = new Vector2[10];

//    [SerializeField]
//    private bool detectSwipeOnlyAfterRelease = false;

//    [SerializeField]
//    private float minDistanceForSwipe = 0f;

//    public static event Action<SwipeData> OnSwipe = delegate { };

//    private void Update()
//    {
//        for (int i = 0; i < Input.touchCount; i++)
//        {
//            Touch touch = Input.touches[i];
    
//            GameObject hitBracket = null;
//            RaycastHit hit;
//            Ray ray = Camera.main.ScreenPointToRay(touch.position);

//            if (Physics.Raycast(ray, out hit))
//            {
//                if(hit.transform.CompareTag("Bracket"))
//                {
//                    hitBracket = hit.transform.gameObject;
//                }
//            }


//            //if (touch.phase == TouchPhase.Began)
//            //{
//            //    fingerUpPosition = touch.position;
//            //    fingerDownPosition = touch.position;
//            //    Debug.Log("smuuu");
//            //}

//            //if (!detectSwipeOnlyAfterRelease && touch.phase == TouchPhase.Moved)
//            //{
//            //    fingerDownPosition = touch.position;
//            //    DetectSwipe(hitBracket);

//            //}

//            //if (touch.phase == TouchPhase.Ended)
//            //{
//            //    fingerDownPosition = touch.position;
//            //    Debug.Log("smuuu");
//            //    DetectSwipe(hitBracket);
//            //}
//        }
//    }

//    private void DetectSwipe(GameObject hitBracket)
//    {
//        if (SwipeDistanceCheckMet())
//        {
//            Debug.Log("YAAAAAS");
//            if (IsHorizontalSwipe())
//            {
//                var direction = fingerDownPosition.x - fingerUpPosition.x > 0 ? SwipeDirection.Right : SwipeDirection.Left;
//                var swipeDistance = HorizontalMovementDistance();
//                SwipeData swipeData = new SwipeData()
//                {
//                    Direction = direction,
//                    StartPosition = fingerDownPosition,
//                    EndPosition = fingerUpPosition
//                };
//                hitBracket.GetComponent<BracketBehaviour>().BracketSwiped(swipeData);
//            }
//            fingerUpPosition = fingerDownPosition;
//        }
//    }

//    private bool IsHorizontalSwipe()
//    {
//        return VerticalMovementDistance() < HorizontalMovementDistance();
//    }

//    private bool SwipeDistanceCheckMet()
//    {
//        return VerticalMovementDistance() > minDistanceForSwipe || HorizontalMovementDistance() > minDistanceForSwipe;
//    }

//    private float VerticalMovementDistance()
//    {
//        return Mathf.Abs(fingerDownPosition.y - fingerUpPosition.y);
//    }

//    private float HorizontalMovementDistance()
//    {
//        return Mathf.Abs(fingerDownPosition.x - fingerUpPosition.x);
//    }

//    private void SendSwipe(SwipeDirection direction)
//    {
//        SwipeData swipeData = new SwipeData()
//        {
//            Direction = direction,
//            StartPosition = fingerDownPosition,
//            EndPosition = fingerUpPosition
//        };
//        OnSwipe(swipeData);
//    }
//}

//public struct SwipeData
//{
//    public Vector2 StartPosition;
//    public Vector2 EndPosition;
//    public SwipeDirection Direction;
//}

//public enum SwipeDirection
//{
//    Up,
//    Down,
//    Left,
//    Right
//}