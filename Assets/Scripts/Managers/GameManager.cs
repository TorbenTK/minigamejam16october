﻿using UnityEngine;

public class GameManager : MonoBehaviour
{

    // Struggle between Urge for fascination VS Fear of abandonment

    // Public scores, available for objects outside of the Game Manager
    [Header("Score gauges")]
    [Range(0, 100)]
    public float UrgeScore;
    [Range(0, 100)]
    public float FearScore;

    public float UrgeIncreaseValue = 0.1f;
    public float UrgeDecreaseValue = 0.1f;
    public float FearIncreaseValue = 0.08f;
    public float FearDecreaseValue = 0.34f;

    // Act on location of player
    [Header("Location logic")]
    public bool IsInSafeZone;

    // UI?

    // Singleton instance
    public static GameManager Instance;
    private void Awake()
    {
        if (Instance is null) Instance = this;

        DontDestroyOnLoad(gameObject); // Exist across time and scenes

        // Initialization
        UrgeScore = 0;
        FearScore = 0;
        IsInSafeZone = true;
    }

    // Once per frame
    void Update()
    {
        // Prevent exceeding of values
        if (FearScore > 100) FearScore = 100;
        if (FearScore < 0) FearScore = 0;
    }

    private void FixedUpdate()
    {
        if (!IsInSafeZone)
        {
            FearScore += FearIncreaseValue;
        }
        else
        {
            FearScore -= FearDecreaseValue;
        }
    }
}
