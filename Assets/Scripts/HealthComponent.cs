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
        private Rigidbody2D playerRigidBody;
        private float health;
        public bool rejectAllDamage;
        private bool isAlive;
        void Start()
        {
            this.statComponent = gameObject.GetComponent<StatComponent>();
            this.playerRigidBody = gameObject.GetComponent<Rigidbody2D>();
            this.health = statComponent.baseHealth;
            this.isAlive = true;    
        }
        public void TakeDamage(DamageInfo damageInfo)
        {
            if (this.rejectAllDamage == true || !isAlive)
            {
                Debug.Log("rejectAllDamage is on or the healthcomponent's gameobject is fucking dead yo. ");
                return;
            }
            if (damageInfo.crit == true) { damageInfo.damage = damageInfo.damage * 2; Debug.Log("attack was a crit, doubled damage");  };
            this.playerRigidBody.AddForce(damageInfo.force);
            this.health = this.health - damageInfo.damage;
            //splitting heads, cutting teeth, feel your void split.
            //must be tired of the noise.
        }

        // Update is called once per frame
        void Update()
        {
            if (this.health <= 0) { Destroy(gameObject); this.isAlive = false; };
        }
    }
}
    