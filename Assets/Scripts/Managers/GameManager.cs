using UnityEngine;

public class GameManager : MonoBehaviour
{

    // Struggle between Urge for fascination VS Fear of abandonment

    // Public scores, available for objects outside of the Game Manager
    [Header("Score gauges")]
    [Range(0, 100)]
    public int UrgeScore;
    [Range(0, 100)]
    public int FearScore;

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
    }

    // Once per frame
    void Update()
    {
        
    }
}
