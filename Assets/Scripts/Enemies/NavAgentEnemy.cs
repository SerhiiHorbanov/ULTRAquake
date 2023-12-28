using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Enemies
{
    [RequireComponent(typeof(NavMeshAgent))]
    public class NavAgentEnemy : Enemy
    {
        public NavMeshAgent agent;

        public override void Awake()
        {
            base.Awake();
            agent = GetComponent<NavMeshAgent>();
        }

        public float DistanceBetweenPlayerAndDestinationSquared()
            => (player.transform.position - agent.destination).sqrMagnitude;
    }
}