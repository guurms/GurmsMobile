using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextBracketCheck : MonoBehaviour
{
    RaycastHit2D hitInfo = new RaycastHit2D();

    public Transform check1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hitInfo = Physics2D.Raycast(check1.position, Vector2.up);
        if (hitInfo)
        {
            //Debug.Log("Yaas we hit something");
            //Debug.Log("Yaas we hit something " + hitInfo.distance);
            if (hitInfo.distance == 0.2f)
            {
                Debug.Log("Yaas we hit something");
            } 
        }
    }
}
