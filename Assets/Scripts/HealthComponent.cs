using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Tell unity that we need this component.
namespace LudumDare46Game
{
    [RequireComponent(typeof(StatComponent))]
    [DisallowMultipleComponent]
    public class HealthComponent : MonoBehaviour
    {
        private StatComponent statComponent;
        private float health;
        public bool rejectAllDamage;
        void Start()
        {
            this.statComponent = gameObject.GetComponent<StatComponent>();
            this.health = statComponent.baseHealth;
        }
        public void TakeDamage(DamageInfo damageInfo)
        {
            if (this.rejectAllDamage == true)
            {
                Debug.Log("rejected damage!");
                return;
            }
            if (damageInfo.crit == true)
            {
                damageInfo.damage = damageInfo.damage * 2;
            }
        }
        // Update is called once per frame
        void Update()
        {
            if (this.health <= 0) { Destroy(gameObject); };
        }
    }
}
    