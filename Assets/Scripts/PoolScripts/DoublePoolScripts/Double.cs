﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Double : MonoBehaviour
{
    //Code that handles returning a slider back to its pool 
    //when it has gone past the top of the screen or been swiped

    //(Maybe, could also be in other scripts I guess. Will have to test pooling system more to know for sure)

    private void OnTriggerEnter2D(Collider2D col)
    {
        GetComponent<DoubleTapBracket>().Reset();
        DoublePool.Instance.ReturnToPool(this);
    }
}
