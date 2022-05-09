using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheRPG.Combat;
using TheRPG.Movement;
using TheRPG.Core;
using System;

namespace TheRPG.Controller
{
    public class EnemyController : MonoBehaviour
    {
        [SerializeField] float chaseDistance = 6f;
        [SerializeField] WayPoints wayPoints;
        [SerializeField] float suspicionTime = 3f;

        Fighter fighter;
        GameObject player;
        Health health;
        int curWayPointIndex = 0;
        float timeLastSawPlayer = Mathf.Infinity;
        Mover mover;

        private void Start()
        {
            fighter = GetComponent<Fighter>();
            health = GetComponent<Health>();
            mover = GetComponent<Mover>();
            player = GameObject.FindWithTag("Player");

        }

        private void Update()
        {
            if (health.GetIsDead())
            {
                HideObject();
                return;
            }
            if (DistanceToPlayer() && fighter.CanAttack(player))
            {
                timeLastSawPlayer = 0;
                fighter.Attack(player);
            }
            else if (timeLastSawPlayer < suspicionTime)
            {
                SuspicionBehavior();
            }
        }

        private void HideObject()
        {
            gameObject.SetActive(false);
        }

        private void SuspicionBehavior()
        {
            GetComponent<ActionScheduler>().CancelCurrentAction();
        }

        private bool DistanceToPlayer()
        {
            Vector3 playerPosition = player.transform.position; 
            return Vector3.Distance(transform.position, playerPosition) < chaseDistance;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(transform.position, chaseDistance);
        }
    }
}
