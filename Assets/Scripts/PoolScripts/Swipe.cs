using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swipe : MonoBehaviour
{
    //Code that handles returning a slider back to its pool 
    //when it has gone past the top of the screen or been swiped

    //(Maybe, could also be in other scripts I guess. Will have to test pooling system more to know for sure)

    private void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("itsa me, mario");
        GetComponent<SwipeBracket>().Reset();
        GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        SwipePool.Instance.ReturnToPool(this);
    }
}
