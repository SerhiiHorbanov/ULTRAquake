using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Weapons.ProjectileBased.Projectiles
{
    public class Grenade : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            Destroy(gameObject);
        }
    }
}