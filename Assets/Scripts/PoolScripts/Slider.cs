using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slider : MonoBehaviour
{
    //Code that handles returning a slider back to its pool 
    //when it has gone past the top of the screen or been swiped

    //(Maybe, could also be in other scripts I guess. Will have to test pooling system more to know for sure)

    private float lifeTime = 0;

    private void OnEnable()
    {
        lifeTime = 0;
    }

    private void Update()
    {
        lifeTime += Time.deltaTime;

        if(lifeTime > 8)
        {
            this.transform.GetChild(0).DetachChildren();
            this.transform.GetChild(1).DetachChildren();
            SliderPool.Instance.ReturnToPool(this);
        }
    }
}
