using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    [Header("Variables")]
    public float MovementSpeed = 2.0f;
    public float RunningSpeedBonus = 3.0f;
    public bool CanRun = true;
    public bool IsRunning = false;

    public float CurrentRunCooldown = 0; // seconds in deltaTime
    public float RunCooldown = 10; // seconds in deltaTime

    public int CurrentStamina = 0;
    public int MaxStamina = 100;

    // Once per frame
    private void Update()
    {
        var xPos = Input.GetAxis("Horizontal");
        var zPos = Input.GetAxis("Vertical");

        var movement = transform.right * xPos + transform.forward * zPos;

        if (Input.GetButton("Jump") && CanRun)
        {
            IsRunning = true;
            controller.Move(movement * (MovementSpeed + RunningSpeedBonus) * Time.deltaTime);
        }
        else
        {
            IsRunning = false;
            controller.Move(movement * MovementSpeed * Time.deltaTime);
        }

        // Stamina depleted
        if (CurrentStamina <= 0 && CanRun)
        {
            CanRun = false;
            CurrentRunCooldown = RunCooldown;
        }
    }

    private void FixedUpdate()
    {
        // Reduce / reset timers timers
        if (!CanRun)
        {
            CurrentRunCooldown -= Time.deltaTime;

            if (CurrentRunCooldown <= 0)
            {
                CanRun = true;
                CurrentStamina = MaxStamina;
            }
        }

        if (IsRunning)
        {
            CurrentStamina--;
        }
    }
}