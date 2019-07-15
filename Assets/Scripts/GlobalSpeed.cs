using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalSpeed : MonoBehaviour
{
    public float currentSpeed;

    public float startSpeed = 1f;
    private float endSpeed = 10f;
    private float addSpeed = 0.034f;

    public static GlobalSpeed Instance;

    private float difficultyIncreaseTimer = 0f;
    private float topTimer = 1f;

    private void Awake()
    {
        Instance = this;
        currentSpeed = startSpeed;
    }

    void Update()
    {
        difficultyIncreaseTimer += Time.deltaTime;

        if(difficultyIncreaseTimer > topTimer && currentSpeed < endSpeed)
        {
            IncreaseDifficulty();
            difficultyIncreaseTimer = 0f;
        }
    }

    private void IncreaseDifficulty()
    {
        currentSpeed += addSpeed;
    }
}
