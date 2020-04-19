using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Tell unity that we need this component.   
namespace LudumDare46Game
{
    [RequireComponent(typeof(StatComponent))]
    [RequireComponent(typeof(HealthComponent))]
    [DisallowMultipleComponent]
    //god tbis is a fuckin mess.
    public class StaffManager : MonoBehaviour
    {
        private HealthComponent healthComponent;
        private StatComponent statComponent;
        private Rigidbody2D playerRigidBody;
        private float vialAmount;
        public bool rejectAllVialSubraction;
        
        void Start()
        {
            this.statComponent = gameObject.GetComponent<StatComponent>();
            this.playerRigidBody = gameObject.GetComponent<Rigidbody2D>();
            this.vialAmount = statComponent.baseVialAmount;
        }
        public void SubtractVial(int amount)
        {
            if (this.rejectAllVialSubraction == true)
            {
                Debug.Log("uhhhh rejectAllVile is on.");
                return;
            }
            this.vialAmount = vialAmount - amount;
        }

        // Update is called once per frame
        void Update()
        {
            if (this.vialAmount <= 0) 
            {
                Debug.Log("uhh ohhh our player character must suffer!");
                DamageInfo damage = new DamageInfo();
                damage.attacker = null;
                damage.crit = false;
                damage.damage = this.healthComponent.health / 2;
                damage.force = new Vector2(0, 0);
                damage.inflictor = null;
                damage.rejected = false;
                this.healthComponent.TakeDamage(damage);
                this.vialAmount = this.statComponent.baseVialAmount; 
            };
        }
    }
}
