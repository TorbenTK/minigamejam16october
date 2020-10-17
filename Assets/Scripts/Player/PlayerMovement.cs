using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    public float speed = 12f;

    // Once per frame
    private void Update()
    {
        var xPos = Input.GetAxis("Horizontal");
        var zPos = Input.GetAxis("Vertical");

        var movement = transform.right * xPos + transform.forward * zPos;

        controller.Move(movement * speed * Time.deltaTime);
    }

    // Physics engine update
    void FixedUpdate()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward);

#if UNITY_EDITOR
        Debug.DrawRay(transform.position, fwd, Color.green);
#endif

        if (Physics.Raycast(transform.position, fwd, 10))
            print("There is something in front of the object!");
    }
}