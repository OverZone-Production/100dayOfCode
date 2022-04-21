using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheRPG.Core;

namespace TheRPG.Combat
{
    public class Health : MonoBehaviour
    {
        [SerializeField] float HP = 100f;
        private bool isDead = false;

        public void TakeDamage(float damage)
        {
            HP = Mathf.Max(HP - damage, 0);
            print(name + "'s Health: " + HP);

            if (HP <= 0 && !isDead)
            {
                Die();
            }
        }

        public bool GetIsDead()
        {
            return isDead;
        }

        private void Die()
        {
            isDead = true;
            GetComponent<Animator>().SetTrigger("die");
            GetComponent<ActionScheduler>().CancelCurrentAction();
        }
    }

}

