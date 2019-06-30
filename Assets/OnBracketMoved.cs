using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnBracketMoved : MonoBehaviour
{
    private float startPositionX;

    private void Start()
    {
        startPositionX = transform.position.x;
    }
    private void Update() 
    {
        if(startPositionX != transform.position.x && transform.childCount != 0) 
        {
            transform.DetachChildren();
        }
    }
}
