using Enemies;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

namespace Enemies.EnemyTypes
{
    public class Walker : NavAgentEnemy
    {
        float distanceBetweenPlayerAndDestinationSquaredLimit = 1f;

        public override void Awake()
        {
            base.Awake();
        }

        private void Update()
        {
            if (DistanceBetweenPlayerAndDestinationSquared() > distanceBetweenPlayerAndDestinationSquaredLimit)
                agent.SetDestination(player.transform.position);
        }
    }
}