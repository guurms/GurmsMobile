using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleTapBracket : MonoBehaviour
{
    private int tapCount;
    private SpriteRenderer sr;
    private Color baseColor;
    
    // Start is called before the first frame update
    void Start()
    {
        tapCount = 0;
        sr = GetComponent<SpriteRenderer>();
        baseColor = sr.color;
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

            if (hitInformation.collider && hitInformation.collider.name == name)
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
            sr.color = new Color(baseColor.r, baseColor.g, baseColor.b, 0.5f);
        }
        if (tapCount == 2)
        {
            Debug.Log("Yaas two");
            Reset();
            DoublePool.Instance.ReturnToPool(GetComponent<Double>());
        }
    }

    public void Reset()
    {
        tapCount = 0;
        sr.color = baseColor;
    }
}
