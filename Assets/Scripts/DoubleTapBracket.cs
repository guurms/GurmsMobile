using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleTapBracket : MonoBehaviour
{
    private int tapCount;
    private SpriteRenderer sr;
    private string myName;
    
    // Start is called before the first frame update
    void Start()
    {
        tapCount = 0;
        myName = name;
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch touch = Input.touches[i];

            Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
            touchPos.z = 0f;

            //Check if its touching the object 
            RaycastHit2D hitInformation = Physics2D.Raycast(touchPos, Camera.main.transform.forward);

            if (hitInformation.collider && hitInformation.collider.name == myName)
            {
                switch (touch.phase)
                {
                    case TouchPhase.Began:
                        Debug.Log("yessor");
                        tapCount++;
                        CheckTap();
                        break;
                    default:
                        break;
                }
            }
        }
    }

    void CheckTap()
    {
        if (tapCount == 1)
        {
            Debug.Log("Yaas one");
            sr.color = new Color(1, 1, 1, 0.5f);
        }
        if (tapCount == 2)
        {
            Debug.Log("Yaas two");
            sr.enabled = false;
        }
    }

    public void ResetBracket()
    {
        tapCount = 0;
        sr.enabled = true;
        sr.color = new Color(1, 1, 1, 1f);
    }
}
