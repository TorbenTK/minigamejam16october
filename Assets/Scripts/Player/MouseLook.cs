using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensitivity = 500f;
    public Transform playerBody;

    private float xRotation;

    // Colliders and raycasting
    private Vector3 fwd; // Forward direction of eyes

    [Header("Colliders and raycasting")]
    public int maxViewDistance = 10;
    public float viewSphereSize = 5.0f;

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
        RaycastHit hit;
        fwd = transform.TransformDirection(Vector3.forward) * maxViewDistance;

#if UNITY_EDITOR
        Debug.DrawRay(transform.position, fwd, Color.green);
#endif

        if (Physics.SphereCast(fwd, viewSphereSize, transform.forward, out hit, maxViewDistance))
        {
            Debug.Log(hit.distance);
        }
    }

    // Draw raw and target gizmo if in view
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawLine(transform.position, transform.position + transform.forward * maxViewDistance);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position + transform.forward * maxViewDistance, viewSphereSize);
    }
}