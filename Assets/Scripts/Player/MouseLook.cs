using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 100f;
    public Transform playerBody;

    private float xRotation;

    // Start is called before the first frame update
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    private void Update()
    {
        var mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        var mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    // Physics engine update
    void FixedUpdate()
    {
        Vector3 fwd = transform.TransformDirection(Vector3.forward) * 10;

#if UNITY_EDITOR
        Debug.DrawRay(transform.position, fwd, Color.green);
#endif

        if (Physics.Raycast(transform.position, fwd, 10))
            print("There is something in front of the object!");
    }
}