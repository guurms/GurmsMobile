using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSpeed : MonoBehaviour
{
    public float currentSpeed;

    private float startSpeed = 1f;
    private float endSpeed = 10f;

    public static GlobalSpeed Instance;

    private float difficultyIncreaseTimer = 0f;

    private void Awake()
    {
        Instance = this;
        currentSpeed = startSpeed;
    }

    void Update()
    {
        difficultyIncreaseTimer += Time.deltaTime;

        if(difficultyIncreaseTimer > 1f && currentSpeed < endSpeed)
        {
            IncreaseDifficulty();
            difficultyIncreaseTimer = 0f;
        }
    }

    private void IncreaseDifficulty()
    {
        currentSpeed += 0.034f;
    }
}
