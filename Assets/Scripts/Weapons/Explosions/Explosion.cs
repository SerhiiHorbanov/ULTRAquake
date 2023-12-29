using HealthAndDamage;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace Weapons.Explosions
{
    public class Explosion : MonoBehaviour
    {
        private ExplosionData explosionData;
        private Damage damage;

        private int framesPassed = 0;
        
        private void FixedUpdate()
        {
            if (explosionData == null)
                return;

            float valueOnCurve = EaseOutExpo((float)framesPassed / explosionData.ExplosionTime);
            float scale = valueOnCurve * explosionData.ExplosionRadius;
            transform.localScale = Vector3.one * scale;

            framesPassed++;

            if (framesPassed >= explosionData.ExplosionTime)
                Destroy(gameObject);
        }

        private float EaseOutExpo(float value)
            => (value == 1) ? 1 : 1 - Mathf.Pow(2, -10 * value);

        public void SetData(ExplosionData explosionData, Damage damage)
        {
            this.explosionData = explosionData;
            this.damage = damage;
        }
    }
}