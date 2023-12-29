using Enemies;
using Player.Movement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(Walk))]
[RequireComponent(typeof(Enemy))]
public class EnemyWalkController : MonoBehaviour
{
    private Walk walk;
    private Enemy enemyComponent;

    private NavMeshPath path;
    
    [SerializeField] private float maxDistance = 100f;
    [SerializeField] private float distanceBetweenPlayerAndDestinationSquaredLimit = 1f;

    private void Awake()
    {
        walk = GetComponent<Walk>();
        enemyComponent = GetComponent<Enemy>();
        path = new NavMeshPath();
    }

    private void FixedUpdate()
    {

        Debug.Log(path.corners.Length);

        if (path.corners.Length < 2)
            return;

        Vector3 walkTo = path.corners[1];
        Vector3 walkToRelativePosition = walkTo - transform.position;
        Vector2 direction = new Vector2(walkToRelativePosition.x, walkToRelativePosition.z);

        walk.SetAbsoluteWalkDirection(direction);
    }
    private void Update()
    {
        if (DistanceBetweenPlayerAndDestinationSquared() > distanceBetweenPlayerAndDestinationSquaredLimit)
        {
            UpdatePath();
        }
    }

    public Vector3 GetClosestNavMeshPosition(Vector3 targetPosition)//ChatGPT's method 😊 (i tried to do the same thing but i didn't work)
    {
        NavMeshHit hit;

        // Try to sample the position on the NavMesh
        if (NavMesh.SamplePosition(targetPosition, out hit, maxDistance, NavMesh.AllAreas))
        {
            // Valid position found on the NavMesh
            return hit.position;
        }
        else
        {
            // No valid position found, handle this case as needed
            //Debug.LogError("No valid position found on the NavMesh");
            return transform.position; // or some default value
        }
    }

    public void UpdatePath()
    {
        Vector3 sampledPosition = GetClosestNavMeshPosition(transform.position);
        Vector3 sampledPlayerPosition = GetClosestNavMeshPosition(enemyComponent.player.transform.position);

        NavMesh.CalculatePath(sampledPosition, sampledPlayerPosition, NavMesh.AllAreas, path);
    }

    public float DistanceBetweenPlayerAndDestinationSquared()
    {
        if (path.corners.Length < 2)
            return distanceBetweenPlayerAndDestinationSquaredLimit + 1;
        return (enemyComponent.player.transform.position - path.corners[1]).sqrMagnitude;
    }
}
