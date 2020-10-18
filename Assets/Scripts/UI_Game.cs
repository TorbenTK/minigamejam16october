using UnityEngine;
using UnityEngine.UI;

public class UI_Game : MonoBehaviour
{
    // Elements required for UI
    [Header("Scores")]
    public Slider UrgeSlider;
    public Slider FearSlider;

    [Header("Stats")]
    public Slider StaminaSlider;

    // Once per frame
    void Update()
    {
        UrgeSlider.value = GameManager.Instance.UrgeScore;
        FearSlider.value = GameManager.Instance.FearScore;

        StaminaSlider.value = GameManager.Instance.StaminaScore;
    }
}
