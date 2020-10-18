using UnityEngine;

public class Waypoint : MonoBehaviour
{
    public Transform[] destinations;
    private string _waypointColliderName;

    private void Start()
    {
        _waypointColliderName = GameManager.Instance.WaypointCollider.name;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        // Draw gizmos to link waypoints together
        if (destinations.Length > 0)
        {
            foreach (var point in destinations)
            {
                Gizmos.DrawLine(transform.position, point.transform.position);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == _waypointColliderName)
        {
            GameManager.Instance.Parent.GetComponent<ParentNavigator>().waypoint = FetchNewWaypoint();
        }
    }

    private Transform FetchNewWaypoint()
    {
        // Handle out of bounds
        if (destinations.Length == 0)
        {
            return GameManager.Instance.Parent.transform; // freeze on location
        }

        return destinations[Random.Range(0, destinations.Length - 1)];
    }
}
