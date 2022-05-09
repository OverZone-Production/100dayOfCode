using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheRPG.Core;
using TheRPG.Combat;

namespace TheRPG.PickUp
{
    public class PickUp : MonoBehaviour
    {
        [SerializeField] PickUpType pickUpType;
        [SerializeField] Health health;
        [SerializeField] Fighter fighter;
        [SerializeField] Level level;
        [SerializeField] int amount;
        private void HideObject()
        {
            gameObject.SetActive(false);
        }

        void Update()
        {
           if(GetComponent<Health>().GetIsDead())
            {
                if (pickUpType == PickUpType.Health)
                {
                    health.gainHealth(amount);
                }
                if (pickUpType == PickUpType.Attack)
                {
                    fighter.DamageBoost(amount);
                }
                if (pickUpType == PickUpType.Defense)
                {
                    fighter.DefenseBoost(amount);
                }
                if (pickUpType == PickUpType.Exp)
                {
                    level.GainExp(amount);
                }
                HideObject();
            }
        }


    }
}
