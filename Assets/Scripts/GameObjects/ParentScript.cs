using System.Collections;
using System.Collections.Generic;
using System.Net.Mail;
using UnityEngine;

public class ParentScript : MonoBehaviour
{
    [Header("Variables")]
    public float SafeZone = 10.0f;
    public float MovementSpeed = 2.0f;

    public float MaxSafeZoneSize = 10.0f;

    // Children objects (should be there)
    private Collider SafeZoneCollider;

    private enum SafeZoneSize
    {
        Grow, Stay, Shrink
    }

    // Start is called before the first frame update
    void Start()
    {
        // Find children
        SafeZoneCollider = gameObject.transform.Find("Collider").GetComponent<Collider>();


    }

    // Update is called once per frame
    void Update()
    {
        // Update Safezone
        SafeZoneCollider.transform.localScale = new Vector3(SafeZone, 1.0f, SafeZone);

    }

    // Draw raw and target gizmo if in view
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, SafeZone);
    }

    // Entering and exiting of safety zone
    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.IsInSafeZone = true;
    }

    private void OnTriggerStay(Collider other)
    {
        GameManager.Instance.IsInSafeZone = true;
        Debug.Log(other.name);
    }

    private void OnTriggerExit(Collider other)
    {
        GameManager.Instance.IsInSafeZone = false;
    }
}
