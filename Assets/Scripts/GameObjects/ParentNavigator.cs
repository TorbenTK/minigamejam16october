using UnityEngine;
using UnityEngine.AI;

public class ParentNavigator : MonoBehaviour
{
    public NavMeshAgent agent;
    public bool IsMoving;

    public Transform waypoint;

    // Start is called before the first frame update
    void Start()
    {
        // Navigation agent settings
        agent.autoBraking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (waypoint)
        {
            agent.SetDestination(waypoint.position);
        }
    }
}
