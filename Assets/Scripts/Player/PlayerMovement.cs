using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    [Header("Variables")]
    public float MovementSpeed = 2.0f;
    public float RunningSpeedBonus = 3.0f;
    public bool CanRun = true;

    public float CurrentRunCooldown = 600.0f;
    public float RunCooldown = 600.0f;

    public int CurrentStamina = 0;
    public int MaxStamina = 500;

    // Once per frame
    private void Update()
    {
        // Reduce / reset timers timers
        if (!CanRun)
        {
            CurrentRunCooldown -= 0.5f;

            if (CurrentRunCooldown <= 0)
            {
                CanRun = true;
                CurrentStamina = MaxStamina;
            }
        }

        var xPos = Input.GetAxis("Horizontal");
        var zPos = Input.GetAxis("Vertical");

        var movement = transform.right * xPos + transform.forward * zPos;

        if (Input.GetButton("Jump") && CanRun)
        {
            CurrentStamina--;

            controller.Move(movement * (MovementSpeed + RunningSpeedBonus) * Time.deltaTime);
        }
        else
        {
            controller.Move(movement * MovementSpeed * Time.deltaTime);
        }

        // Stamina depleted
        if (CurrentStamina <= 0 && CanRun)
        {
            CanRun = false;
            CurrentRunCooldown = RunCooldown;
        }
    }
}