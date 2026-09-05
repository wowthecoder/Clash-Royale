using UnityEngine;
using UnityEngine.AI;

/// <summary>
/// Moves a unit toward its target (e.g. the enemy king tower) using NavMesh pathfinding.
/// Movement-only for this milestone: no HP, no attacking yet.
/// </summary>
[RequireComponent(typeof(NavMeshAgent))]
public class KnightController : MonoBehaviour
{
    [Tooltip("The transform this unit walks toward (enemy king tower for now).")]
    public Transform target;

    NavMeshAgent agent;

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        if (target != null)
            agent.SetDestination(target.position);
    }

    /// <summary>Assign the target after instantiation (used by UnitSpawner).</summary>
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
        if (agent == null) agent = GetComponent<NavMeshAgent>();
        if (target != null && agent.isOnNavMesh)
            agent.SetDestination(target.position);
    }
}
