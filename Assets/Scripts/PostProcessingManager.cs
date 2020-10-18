using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PostProcessingManager : MonoBehaviour
{
    [Range(0, 100)]
    public float FearEffectThreshold = GameManager.Instance.FearUpperThreshold - 20;

    public Volume volume;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize post-processing without applying fear-effect
        SetIntensity(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.Instance.FearScore > FearEffectThreshold && !GameManager.Instance.IsInSafeZone)
        {
            // Start increasing the fear-effect from current value to max.
            SetIntensity(Mathf.Max(0, (GameManager.Instance.FearScore - 50) * 2 / 100));
        }
        else if (GameManager.Instance.IsTooAfraid && GameManager.Instance.IsInSafeZone)
        {
            // Decrease the afraid-effect until GameManager.FearScore reaches GameManager.FearLowerThreshold
            SetIntensity(GameManager.Instance.FearScore / 100);
        }
        else
        {
            // Player is safe. Set post processing to defaults.
            SetIntensity(0);
        }

        // TODO: Figure out what to do with afraid-effect when player IsTooAfraid but FearScore < 50 (GameManager.Instance.IsTooAfraid && !GameManager.Instance.IsInSafeZone))
    }
    
    void SetIntensity(float intensity = 0)
    {
        // Set the intensity of the effect to a float between 0 and 1
        if (intensity < 0)
        {
            intensity = 0;
        }
        else if (intensity > 1) 
        {
            intensity = 1;
        }
        volume.weight = intensity;
    }
}
