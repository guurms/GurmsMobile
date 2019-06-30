using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BracketBehaviour : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void BracketSwiped(SwipeData swipeData) 
    {
        Debug.Log("Ive been swiped!");
        var dir = swipeData.Direction == SwipeDirection.Left ? -1 : 1;
        transform.position += new Vector3(transform.position.x + 5f * dir, transform.position.y, transform.position.z);
    }
}
