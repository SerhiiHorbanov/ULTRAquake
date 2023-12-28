using System;

namespace HealthAndDamage
{
    [Serializable]
    public struct Damage
    {
        public float damageValue;
        public DamageType type;
        //also we need some way of identifying who dealt the damage but i'm not sure how

        public Damage(float damageValue, DamageType type)
        {
            this.damageValue = damageValue;
            this.type = type;
        }

        public static Damage operator *(Damage damage, float multiplier)
        {
            damage.damageValue *= multiplier;
            return damage;
        }
        public static Damage operator /(Damage damage, float denominator)
        {
            damage.damageValue /= denominator;
            return damage;
        }
        public static Damage operator +(Damage damage, float addition)
        {
            damage.damageValue += addition;
            return damage;
        }
        public static Damage operator -(Damage damage, float subtractor)
        {
            damage.damageValue -= subtractor;
            return damage;
        }

        public override string ToString()
            => $"Damage(damageValue = {damageValue}, type = {type})";
    }
}
