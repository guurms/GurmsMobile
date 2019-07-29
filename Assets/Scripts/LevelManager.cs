using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance { get; private set; }
    public float time;

    private void Awake()
    {
        Instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        time = 0f;   
    }
    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    }

    public GameObject GetRandomBracketBasedOnLevel()
    {
        if (time < 30f)
        {
            return LevelOne();
        }
        if (time < 60f)
        {
            return LevelTwo();
        }
        if (time < 90f)
        {
            return LevelThree();
        }
        if (time < 120f)
        {
            return LevelFour();
        }
        else
        {
            return LevelFour();
        }
    }

    public GameObject LevelOne()
    {
        int randomNum = Random.Range(1, 5);
        if (randomNum == 1 || randomNum == 2)
        {
            return SwipePool.Instance.Get().gameObject;
        }
        else
        {
            return null;
        }
    }

    public GameObject LevelTwo()
    {
        int randomNum = Random.Range(1, 5);
        if (randomNum == 1 || randomNum == 2)
        {
            return SwipePool.Instance.Get().gameObject;
        }
        if (randomNum == 3)
        {
            return HeavyPool.Instance.Get().gameObject;
        }
        else
        {
            return null;
        }
    }

    public GameObject LevelThree()
    {
        int randomNum = Random.Range(1, 7);
        if (randomNum == 1 || randomNum == 2)
        {
            return SwipePool.Instance.Get().gameObject;
        }
        if (randomNum == 3)
        {
            return HeavyPool.Instance.Get().gameObject;
        }
        if (randomNum == 4)
        {
            return DoublePool.Instance.Get().gameObject;
        }
        else
        {
            return null;
        }
    }

    public GameObject LevelFour()
    {
        int randomNum = Random.Range(1, 7);
        if (randomNum == 1 || randomNum == 2)
        {
            return SwipePool.Instance.Get().gameObject;
        }
        if (randomNum == 3)
        {
            return HeavyPool.Instance.Get().gameObject;
        }
        if (randomNum == 4)
        {
            return DoublePool.Instance.Get().gameObject;
        }
        if (randomNum == 5)
        {
            return DeathPool.Instance.Get().gameObject;
        }
        else
        {
            return null;
        }
    }
}
