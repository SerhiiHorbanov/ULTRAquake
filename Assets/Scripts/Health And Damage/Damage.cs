using System;

namespace HealthAndDamage
{
    [Serializable]
    public struct Damage
    {
        public float damageValue;
        public DamageType type;
        //also we need some way of identifying who dealt the damage but i'm not sure how
    }
}
