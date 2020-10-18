using UnityEngine;

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

    public float FearUpperThreshold = 70;
    public float FearLowerThreshold = 5;

    // Act on location of player
    [Header("Location logic")]
    public bool IsInSafeZone;
    public bool IsTooAfraid;

    // Managed externally
    [HideInInspector]
    public float StaminaScore;

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
        if (UrgeScore > 100) UrgeScore = 100;
        if (UrgeScore < 0) UrgeScore = 0;

        if (FearScore > 100) FearScore = 100;
        if (FearScore < 0) FearScore = 0;

        // Past a threshold, character gets too afraid.
        // Heavily decreases Urge and stops its increase
        if (FearScore > FearUpperThreshold)
        {
            IsTooAfraid = true;
        }
        if (IsTooAfraid && FearScore <= FearLowerThreshold)
        {
            IsTooAfraid = false;
        }
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

        if (IsTooAfraid)
        {
            UrgeScore -= UrgeDecreaseValue * 3;
        }

        // The urge for excitement strikes! If it hits 100, character loses control.
        if (!IsTooAfraid)
        {
            UrgeScore += UrgeIncreaseValue;
        }
    }
}
