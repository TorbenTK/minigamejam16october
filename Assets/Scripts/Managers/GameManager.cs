using UnityEngine;

public class GameManager : MonoBehaviour
{
    // Struggle between Urge for fascination VS Fear of abandonment

    // Public variables, available for objects outside of the Game Manager
    [Header("Objects")]
    public GameObject Player;
    public GameObject Parent;
    [HideInInspector]
    public Transform WaypointCollider;

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

        WaypointCollider = Parent.transform.Find("WaypointCollider");
    }

    // Once per frame
    private void Update()
    {
        // Prevent exceeding of values
        if (UrgeScore > 100) UrgeScore = 100;
        if (UrgeScore < 0) UrgeScore = 0;

        if (FearScore > 100) FearScore = 100;
        if (FearScore < 0) FearScore = 0;

        // Past a threshold, character gets too afraid.
        // Heavily decreases Urge and stops its increase
        if (FearScore > 70)
        {
            IsTooAfraid = true;
        }
        if (IsTooAfraid && FearScore <= 5)
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
            DecreaseUrge();
        }

        // The urge for excitement strikes! If it hits 100, character loses control.
        if (!IsTooAfraid)
        {
            UrgeScore += UrgeIncreaseValue;
        }
    }

    public void DecreaseUrge()
    {
        UrgeScore -= UrgeDecreaseValue * 3;
    }
}