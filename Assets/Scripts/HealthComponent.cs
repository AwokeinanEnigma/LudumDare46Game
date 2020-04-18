using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Tell unity that we need this component.
namespace LudumDare46Game
{
    [RequireComponent(typeof(StatComponent))]

    public class HealthComponent : MonoBehaviour
    {
        private StatComponent statComponent;
        private float health;
        void Start()
        {
            this.statComponent = gameObject.GetComponent<StatComponent>();
            this.health = statComponent.baseHealth;
        }
        void TakeDamage(DamageInfo damageInfo)
        {
            //do stuff
        }
        // Update is called once per frame
        void Update()
        {
            if (this.health <= 0) { Destroy(gameObject); };
        }
    }
}
