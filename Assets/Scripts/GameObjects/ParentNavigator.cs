using UnityEngine;
using UnityEngine.AI;

public class ParentNavigator : MonoBehaviour
{
    public NavMeshAgent agent;
    public bool IsMoving;
    public Animator Anim;

    public Transform waypoint;

    // Start is called before the first frame update
    private void Start()
    {
        // Navigation agent settings
        agent.autoBraking = false;
    }

    // Update is called once per frame
    private void Update()
    {
        if (IsMoving)
        {
            Anim.SetFloat("Speed", 1f);
        }
        if (waypoint)
        {
            agent.SetDestination(waypoint.position);
        }
    }
}