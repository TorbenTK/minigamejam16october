using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;

    private void Update()
    {
        var xPos = Input.GetAxis("Horizontal");
        var zPos = Input.GetAxis("Vertical");

        var movement = transform.right * xPos + transform.forward * zPos;

        controller.Move(movement * speed * Time.deltaTime);
    }
}