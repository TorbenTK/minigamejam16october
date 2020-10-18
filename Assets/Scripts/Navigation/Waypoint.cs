using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Waypoint : MonoBehaviour
{
    public Transform[] destinations;
    private string _waypointColliderName;

    public Color DebugColor = Color.blue;

    private void Start()
    {
        _waypointColliderName = GameManager.Instance.WaypointCollider.name;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = DebugColor;

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

        // Return direction
        var r = Random.Range(0, destinations.Length);

        Debug.Log(destinations[r].name);
        return destinations[r];
    }
}
