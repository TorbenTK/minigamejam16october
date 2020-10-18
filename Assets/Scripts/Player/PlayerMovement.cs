using System;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    [Header("Variables")]
    public float MovementSpeed = 2.0f;

    public float RunningSpeedBonus = 3.0f;
    public bool CanRun = true;
    public bool IsRunning = false;
    public bool IsDistracted = false;

    public float CurrentRunCooldown = 0; // seconds in deltaTime
    public float RunCooldown = 10; // seconds in deltaTime

    public int CurrentStamina = 0;
    public int MaxStamina = 100;

    [Header("PlayerNavMesh")]
    public NavMeshAgent agent;

    // Once per frame
    private void Update()
    {
        if (!IsDistracted)
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

            if (GameManager.Instance.UrgeScore > 99)
            {
                IsDistracted = true;
                agent.isStopped = false;
                DistractedPathfinding();
            }
        }

        if (IsDistracted && GameManager.Instance.UrgeScore < 50)
        {
            IsDistracted = false;
            agent.isStopped = true;
        }


        // Stamina depleted
        if (CurrentStamina <= 0 && CanRun)
        {
            CanRun = false;
            CurrentRunCooldown = RunCooldown;
        }

        // Expose to GameManager
        if (GameManager.Instance)
        {
            GameManager.Instance.StaminaScore = CurrentStamina;
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

    // Full urge bar takes your control!
    void DistractedPathfinding()
    {
        GameObject[] taggedObjects = GameObject.FindGameObjectsWithTag("ShinyObject");
        float closestDistance = 900000000;
        Vector3 destination = new Vector3();

        foreach (var target in taggedObjects)
        {
            var distance = Vector3.Distance(transform.position, target.transform.position);

            if (distance <= closestDistance)
            {
                closestDistance = distance;
                destination = target.transform.position;
            }
        }

        agent.SetDestination(destination); // TODO BUG: fix y coordinate of the Player.
    }
}