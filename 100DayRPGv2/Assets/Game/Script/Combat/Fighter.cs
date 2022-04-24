using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheRPG.Movement;
using TheRPG.Core;

namespace TheRPG.Combat
{
    public class Fighter : MonoBehaviour, IAction
    {
        [SerializeField] float atk = 5;
        [SerializeField] float def = 10;
        [SerializeField] float weaponRange = 2f;
        [SerializeField] float weaponDamage = 5f;
        [SerializeField] float timeBetweenAttack = 1f;
        [SerializeField] float targetDef = 0f;
        Transform target;
        float timeSinceLastAttack = Mathf.Infinity;

        void Update()
        {
            timeSinceLastAttack += Time.deltaTime;
            if (target == null) return;
            if (!GetIsInRange())
            {
                GetComponent<Mover>().MoveTo(target.position);
            }
            else
            {
                GetComponent<Mover>().Cancel();
                AttackBehaviour();
            }
        }

        private void AttackBehaviour()
        {
            transform.LookAt(target);
            bool isDead = target.GetComponent<Health>().GetIsDead();
            if (timeSinceLastAttack > timeBetweenAttack && !isDead)
            {
                AttackAction();
                timeSinceLastAttack = 0;
            }
            if (isDead)
            {
                Cancel();
            }
        }

        private void AttackAction()
        {
            Animator animator = GetComponent<Animator>();
            animator.SetTrigger("attack");
        }

        public bool CanAttack(GameObject combatTarget)
        {
            if (combatTarget == null) return false;
            Health targetHealth = combatTarget.GetComponent<Health>();

            return targetHealth != null && !targetHealth.GetIsDead();
        }

        public float GetDef()
        {
            return def;
        }

        private bool GetIsInRange()
        {
            return Vector3.Distance(transform.position, target.position) < weaponRange;
        }

        public void Attack(GameObject combatTarget)
        {
            GetComponent<ActionScheduler>().StartAction(this);
            target = combatTarget.transform;
        }

        public void GetTargetDef(GameObject combatTarget)
        {
            targetDef = combatTarget.GetComponent<Fighter>().GetDef();
        }

        public void Cancel()
        {
            GetComponent<Animator>().SetTrigger("stopAttack");
            targetDef = 0;
            target = null;
        }

        // Animation Event Methods
        void Hit()
        {
            if (target != null)
            {
                float totalDamage = weaponDamage + atk - targetDef;
                target.GetComponent<Health>().TakeDamage(totalDamage);
            }
        }

        public void DamageBoost(float boost)
        {
            atk += boost;
        }

        public void DefenseBoost(float boost)
        {
            def += boost;
        }
    }
}


