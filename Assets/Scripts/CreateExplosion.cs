using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LudumDare46Game
{

    public class BlastAttack
    {
        public void CreateExplosion(Vector2 location, float angle, DamageInfo damageInfo)
        {
            //fuck this stupid fucking unity plugin
            Collider2D[] objectsInRange = Physics2D.OverlapBoxAll(location, new Vector2(1,1), angle);
            foreach (Collider2D col in objectsInRange)
            {
                HealthComponent healthComponent = col.GetComponent<HealthComponent>();
                if (healthComponent != null)
                {
                    healthComponent.TakeDamage(damageInfo);

                }
            }
            //thanks for nothing unity!
            //again, literal hot garbage!
        }
    }
}