using UnityEngine;

public class ParentScript : MonoBehaviour
{
    [Header("Variables")]
    public float SafeZoneRadius = 10.0f;
    public float MovementSpeed = 4.0f;

    public float MaxSafeZoneRadius = 10.0f;

    // Children objects (should be there)
    [Header("Related game objects")]
    public string PlayerName = "Player";
    private SphereCollider SafeZoneCollider;

    private GameManager _gm;

    // Start is called before the first frame update
    void Start()
    {
        // Find children
        SafeZoneCollider = GetComponent<SphereCollider>();
        _gm = GameManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        // Decrease Safezone if child passes fear threshold (optional?)

        if (_gm.FearScore > 40)
        {
            Debug.Log("True");
            SafeZoneRadius = MaxSafeZoneRadius * (1 - ((_gm.FearScore - 40) / 105));
        }
        else
        {
            // Update Safezone
            SafeZoneRadius = MaxSafeZoneRadius;
        }

        SafeZoneCollider.radius = SafeZoneRadius;
    }

    // Draw raw and target gizmo if in view
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, SafeZoneRadius);
    }

    // Entering and exiting of safety zone
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == PlayerName)
        {
            _gm.IsInSafeZone = true;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.name == PlayerName)
        {
            _gm.IsInSafeZone = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.name == PlayerName)
        {
            _gm.IsInSafeZone = false;
        }
    }
}
